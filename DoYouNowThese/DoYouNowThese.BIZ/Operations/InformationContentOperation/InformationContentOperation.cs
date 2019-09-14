using DoYouNowThese.BIZ.Operations.InformationReadLog;
using DoYouNowThese.CommonModel.InformationContentModel;
using DoYouNowThese.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoYouNowThese.BIZ.Operations.InformationContentOperation
{
   public class InformationContentOperation
    {
        DoYouNowTheseContext context;
        InformationReadLogOperation informationReadLogOperation;
        public InformationContentOperation(DoYouNowTheseContext _context)
        {
            context = _context;
            informationReadLogOperation = new InformationReadLogOperation(context);
        }

        public InformationContent GetSingleInformationContent(int appUserId=0)
        {
            List<int> readList = informationReadLogOperation.GetReadedInformationContentByAppUserId(appUserId);
            InformationContent informationContent = new InformationContent();
            if (readList != null)
            {
                 informationContent = context.InformationContent.Include(s=>s.Author).Include(a=>a.Category).Where(s => s.IsActive && !s.IsDeleted && !readList.Contains(s.InformationContentId)).OrderBy(s => Guid.NewGuid()).Take(1).SingleOrDefault();
            }
            else
            {
                informationContent = context.InformationContent.Where(s => s.IsActive && !s.IsDeleted).OrderBy(s => Guid.NewGuid()).Take(1).SingleOrDefault();
            }
            return informationContent;
        }
    }
}
