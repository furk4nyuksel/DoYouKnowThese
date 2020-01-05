using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoYouNowThese.UI.Areas.Admin.Models.InformationContent
{
    public class InformationContentCRUDModel
    {
        public int InformationContentId { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string PostImagePath { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int LikeCount { get; set; }
        public string PathExtension { get; set; }

        public IFormFile InformationImage { get; set; }

        #region SelectList

        public SelectList CategoryList { get; set; }

        #endregion SelectList
    }
}
