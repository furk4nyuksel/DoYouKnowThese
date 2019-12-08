using DoYouNowThese.CommonModel.Infrastructure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.InformationContentModel
{
   public class InformationApiContentCRUDModel: GeneralModel
    {
        public int InformationContentId { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        public string PostImagePath { get; set; }
        public int? CategoryId { get; set; }
        public int? AuthorId { get; set; }
        public int LikeCount { get; set; }
        public List<IFormFile> FormFileList { get; set; }
    }
}
