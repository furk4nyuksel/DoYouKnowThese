using DoYouNowThese.BIZ.Utility;
using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoYouNowThese.BIZ.Operations.LogEntityOperation
{
   public static class LogEntityOperation
    {
       public static List <LogEntity> logEntityList;

        public static async void Insert(LogEntity entity)
        {
            if (logEntityList != null)
            {
                logEntityList.Add(entity);

                if (logEntityList.Count() > 900)
                {
                    StaticContext.GetInstance().LogEntity.AddRange(logEntityList);
                    StaticContext.GetInstance().SaveChanges();
                }
            }
            else
            {
                logEntityList = new List<LogEntity>();
            }
        }
    }
}
