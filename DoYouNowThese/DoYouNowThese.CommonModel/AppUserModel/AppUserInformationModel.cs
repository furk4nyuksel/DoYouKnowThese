using DoYouNowThese.CommonModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.AppUserModel
{
  public  class AppUserInformationModel: GeneralModel
    {
        public int AppUserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }
    }
}
