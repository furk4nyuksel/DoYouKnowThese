﻿using System;
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
    public class TokenController : BaseApiController
    {
        DoYouNowTheseContext db;
        AppUserOperation appUserOperation;
        public TokenController()
        {
            db = new DoYouNowTheseContext();
            appUserOperation = new AppUserOperation(db);
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Route("~/api/[controller]/Post")]
        //public IActionResult Post([FromBody]AppUserLoginModel request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = appUserOperation.GetLoginUser(request.UserName, request.Password);
        //        if (user == null)
        //        {
        //            return Unauthorized();
        //        }

        //        var claims = new[]
        //        {
        //    new Claim(JwtRegisteredClaimNames.Sub, request.UserName),
        //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        //};

        //        var token = new JwtSecurityToken
        //        (
        //            issuer: "www.test.com", //appsettings.json içerisinde bulunan issuer değeri
        //            audience: "www.test.com",//appsettings.json içerisinde bulunan audince değeri
        //            claims: claims,
        //            expires: DateTime.UtcNow.AddDays(30), // 30 gün geçerli olacak
        //            notBefore: DateTime.UtcNow,
        //            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString())),//appsettings.json içerisinde bulunan signingkey değeri
        //                    SecurityAlgorithms.HmacSha256)
        //        );
        //        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        //    }
        //    return BadRequest();
        //}

        [Route("GetUserToken")]
        [HttpPost]
        public IActionResult GetUserToken([FromBody]AppUserLoginModel user)
        {
            var appUser = appUserOperation.GetLoginUser(user.UserName, user.Password);

            if (appUser!=null)
            {
                AppUserModel appUserModel = new AppUserModel();
                string tokenKey = GenerateToken(user.UserName);
                appUserModel.TokenKey = tokenKey;
                appUserModel.AppUser = appUser;
                return Json(appUserModel);
            }
    
            return Unauthorized();
        }

        [Route("GetAnonimToken")]
        [HttpPost]
        public IActionResult GetAnonimToken()
        {
            return new ObjectResult(GenerateToken(Guid.NewGuid().ToString()));
        }


        private string GenerateToken(string userName)
        {
            var someClaims = new Claim[]{
                new Claim(JwtRegisteredClaimNames.UniqueName,userName),
                new Claim(JwtRegisteredClaimNames.Email,"info@teknohisar.com"),
                new Claim(JwtRegisteredClaimNames.NameId,Guid.NewGuid().ToString())
            };

            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu_benim_muhtesem_uzunluktaki_muhtesem_saklanmis_guvelik_keyim"));
            var token = new JwtSecurityToken(
                issuer: "194.169.120.27",
                audience: "194.169.120.27",
                claims: someClaims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

 


    }
}