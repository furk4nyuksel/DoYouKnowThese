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
            List<int> contentListId = context.InformationReadLog.Where(s => s.AppUserId == appUserId&&s.IsActive&&!s.IsDeleted).Select(m=>m.InformationContentId).ToList();
            return contentListId;
        }
    }
}
