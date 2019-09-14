using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.InformationContentModel
{
  public  class InformationContentSingleDataModel
    {
        public string Title { get; set; }

        public string Explanation { get; set; }

        public string ImagePath { get; set; }

        public string CategoryName { get; set; }

        public string AuthorFullName { get; set; }

        public string LikeCount { get; set; }
    }
}
