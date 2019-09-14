using System;
using System.Collections.Generic;

namespace DoYouNowThese.DATA.Models
{
    public partial class InformationContent
    {
        public InformationContent()
        {
            InformationReadLog = new HashSet<InformationReadLog>();
        }

        public int InformationContentId { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string PostImagePath { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int? LikeCount { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public AppUser Author { get; set; }
        public Category Category { get; set; }
        public ICollection<InformationReadLog> InformationReadLog { get; set; }
    }
}
