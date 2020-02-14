using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoYouNowThese.BIZ.Operations.InformationReadLog
{
    public class InformationReadLogOperation
    {
        DoYouNowTheseContext context;

        public InformationReadLogOperation(DoYouNowTheseContext _context)
        {
            context = _context;
        }

        public void InsertInformationContentReadList(DATA.Models.InformationReadLog informationReadLog)
        {
            context.InformationReadLog.Add(informationReadLog);
            context.SaveChanges();
        }
        public List<int> GetReadedInformationContentByAppUserId(int appUserId)
        {
            List<int> contentListId = context.InformationReadLog.Where(s => s.AppUserId == appUserId && s.IsActive && !s.IsDeleted).Select(m => m.InformationContentId).ToList();
            return contentListId;
        }

        public int RemoveAllAppUserLog(int appuUserId)
        {
            List<DoYouNowThese.DATA.Models.InformationReadLog> informationReadLogList = context.InformationReadLog.Where(s => s.AppUserId == appuUserId && s.IsActive && !s.IsDeleted).ToList();

            int counter = 0;
            foreach (var log in informationReadLogList)
            {
                counter += 1;
                log.IsDeleted = true;
            }
            context.SaveChanges();
            return counter;
        }
    }
}
