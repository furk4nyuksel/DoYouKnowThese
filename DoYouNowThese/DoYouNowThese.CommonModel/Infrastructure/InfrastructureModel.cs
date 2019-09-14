using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.CommonModel.Infrastructure
{
   public class InfrastructureModel<T>
    {
        public bool ResultStatus { get; set; }

        public T ResultModel { get; set; }

    }
}
