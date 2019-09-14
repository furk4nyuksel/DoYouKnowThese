using System;
using System.Collections.Generic;

namespace DoYouNowThese.DATA.Models
{
    public partial class Category
    {
        public Category()
        {
            InformationContent = new HashSet<InformationContent>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string CategoryImagePath { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<InformationContent> InformationContent { get; set; }
    }
}
