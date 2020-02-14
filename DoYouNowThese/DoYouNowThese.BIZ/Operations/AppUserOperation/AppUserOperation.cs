using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoYouNowThese.BIZ.Operations.AppUserOperation
{
    public class AppUserOperation
    {
        DoYouNowTheseContext context;

        public AppUserOperation(DoYouNowTheseContext _context)
        {
            context = _context;
        }

        public AppUser GetLoginUser(string userName, string password)
        {
          return context.AppUser.Where(s => s.Email.Equals(userName) && s.Password.Equals(password)&&s.IsActive&&!s.IsDeleted).SingleOrDefault();
        }

        public AppUser GetById(int id=0)
        {
            return context.AppUser.Where(s => s.AppUserId==id && s.IsActive && !s.IsDeleted).SingleOrDefault();
        }

        public void Update(AppUser entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
