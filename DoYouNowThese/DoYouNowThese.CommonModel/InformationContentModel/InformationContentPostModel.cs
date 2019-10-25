using DoYouNowThese.CommonModel.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.InformationContentModel
{
    public class InformationContentPostModel:GeneralModel
    {
        public int AppUserId { get; set; }

        public int CategoryId { get; set; }
    }
}
