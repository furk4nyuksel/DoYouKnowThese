using System;
using System.Collections.Generic;

namespace DoYouNowThese.DATA.Models
{
    public partial class LogEntity
    {
        public int LogEntityId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public int? AppUserId { get; set; }
        public string ActionType { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ApiControllerName { get; set; }
        public string ApiActionName { get; set; }

        public AppUser AppUser { get; set; }
    }
}
