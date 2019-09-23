using DoYouNowThese.CommonModel.AppUserModel;
using DoYouNowThese.DATA.Models;
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
    }
}
