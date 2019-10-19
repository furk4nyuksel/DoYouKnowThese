using DoYouNowThese.BIZ.Utility;
using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoYouNowThese.BIZ.Operations.LogEntityOperation
{
   public static class LogEntityOperation
    {

        public static async void Insert(LogEntity entity)
        {
            StaticContext.GetInstance().LogEntity.Add(entity);
            StaticContext.GetInstance().SaveChanges();
        }
    }
}
