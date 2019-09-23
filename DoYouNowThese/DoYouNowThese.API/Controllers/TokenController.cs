using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoYouNowThese.BIZ.Operations.AppUserOperation;
using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.DATA.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DoYouNowThese.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        DoYouNowTheseContext db;
        AppUserOperation appUserOperation;
        public TokenController()
        {
            db = new DoYouNowTheseContext();
            appUserOperation = new AppUserOperation(db);
        }

        public object AppuserOperation { get; }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/[controller]/Post")]
        public IActionResult Post([FromBody]AppUserLoginModel request)
        {
            if (ModelState.IsValid)
            {
                var user = appUserOperation.GetLoginUser(request.UserName, request.Password);
                if (user == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, request.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var token = new JwtSecurityToken
                (
                    issuer: "www.test.com", //appsettings.json içerisinde bulunan issuer değeri
                    audience: "www.test.com",//appsettings.json içerisinde bulunan audince değeri
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(30), // 30 gün geçerli olacak
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())),//appsettings.json içerisinde bulunan signingkey değeri
                            SecurityAlgorithms.HmacSha256)
                );
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest();
        }

    }
}