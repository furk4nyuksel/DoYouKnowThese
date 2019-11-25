using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.AppUserModel
{
   public class AppUserModel
    {
        public AppUser AppUser { get; set; }

        public string TokenKey { get; set; }

        public bool Result { get; set; }
    }
}
