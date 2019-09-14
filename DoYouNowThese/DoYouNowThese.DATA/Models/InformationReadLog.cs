using System;
using System.Collections.Generic;

namespace DoYouNowThese.DATA.Models
{
    public partial class InformationReadLog
    {
        public int InformationReadLogId { get; set; }
        public int? AppUserId { get; set; }
        public int? InformationContentId { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public AppUser AppUser { get; set; }
        public InformationContent InformationContent { get; set; }
    }
}
