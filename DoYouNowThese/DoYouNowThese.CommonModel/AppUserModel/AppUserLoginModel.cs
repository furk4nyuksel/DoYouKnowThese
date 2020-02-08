using DoYouNowThese.CommonModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.AppUserModel
{
    public class AppUserLoginModel:GeneralModel
    {
        public int AppUserId { get; set; }

        public string UserName { get; set; }

        public string NowPassword { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }

        public string Email { get; set; }
    }
}
