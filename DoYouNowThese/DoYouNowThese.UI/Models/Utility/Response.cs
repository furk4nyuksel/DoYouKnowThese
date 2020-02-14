using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoYouNowThese.UI.Models.Utility
{
    public class Response: ResponseGeneralModel
    {
    }

    public class Response<T>: ResponseGeneralModel
    {
        public T Data { get; set; }
    }

    public class ResponseGeneralModel
    {
        public bool Status { get; set; }

        public bool Refresh { get; set; }

        public string Message { get; set; }

        public string RedirectUrl { get; set; }
    }
}
