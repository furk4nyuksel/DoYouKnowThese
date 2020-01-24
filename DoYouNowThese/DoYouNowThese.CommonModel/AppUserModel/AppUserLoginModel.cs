using DoYouNowThese.CommonModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.AppUserModel
{
    public class AppUserLoginModel:GeneralModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
