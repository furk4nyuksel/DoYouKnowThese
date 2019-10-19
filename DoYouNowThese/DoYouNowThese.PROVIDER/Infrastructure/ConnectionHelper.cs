using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.PROVIDER.Infrastructure
{
    public static class ConnectionHelper
    {
        public static string GetConnectionUrl()
        {
            string url = "http://194.169.120.27/api/";
            return url;
        }
    }
}
