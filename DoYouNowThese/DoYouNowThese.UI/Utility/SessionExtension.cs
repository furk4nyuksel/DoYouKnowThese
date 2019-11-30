using DoYouNowThese.CommonModel.AppUserModel;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoYouNowThese.UI.Utility
{
    public static class SessionExtension
    {
        //attirbute sessiona bak
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) :
                JsonConvert.DeserializeObject<T>(value);
        }

        public static string GetSessionUserTokeyKey(this ISession session)
        {
            AppUserModel userModel = new AppUserModel();
            userModel = SessionExtension.Get<AppUserModel>(session, "Login");
            return userModel.TokenKey;
        }
        public static AppUserModel GetSessionUser(this ISession session)
        {
            AppUserModel userModel = new AppUserModel();
            userModel = SessionExtension.Get<AppUserModel>(session, "Login");
            return userModel;
        }
    }
}
