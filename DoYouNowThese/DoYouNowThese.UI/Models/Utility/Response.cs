using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoYouNowThese.UI.Models.Utility
{
    public class Response
    {
        public bool Status { get; set; }

        public string Message { get; set; }
    }

    public class Response<T>
    {
        public bool Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
