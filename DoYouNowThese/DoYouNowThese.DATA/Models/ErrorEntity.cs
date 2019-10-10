using System;
using System.Collections.Generic;

namespace DoYouNowThese.DATA.Models
{
    public partial class ErrorEntity
    {
        public int ErrorEntityId { get; set; }
        public int? AppUserId { get; set; }
        public string MessageText { get; set; }
        public string InnerExceptionText { get; set; }
        public string SourceText { get; set; }
        public string StackTraceText { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string ParameterName { get; set; }
        public int? StatusCode { get; set; }
        public string Status { get; set; }
        public string UserBrowser { get; set; }
        public string UserIp { get; set; }
        public string ApiController { get; set; }
        public string ApiAction { get; set; }
        public string WebController { get; set; }
        public string WebAction { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public AppUser AppUser { get; set; }
    }
}
