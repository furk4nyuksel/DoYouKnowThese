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
        public void Insert(InformationContent entity)
        {
            context.InformationContent.Add(entity);
            context.SaveChanges();
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

        public InformationContent GetCategorySingleInformationContent(int appUserId=0,int categoryId = 0)
        {
            List<int> readList = informationReadLogOperation.GetReadedInformationContentByAppUserId(appUserId);
            InformationContent informationContent = new InformationContent();
            if (readList != null)
            {
                informationContent = context.InformationContent.Include(s => s.Author).Include(a => a.Category).Where(s => s.IsActive && !s.IsDeleted && !readList.Contains(s.InformationContentId)&&s.CategoryId==categoryId).OrderBy(s => Guid.NewGuid()).Take(1).SingleOrDefault();
            }
            else
            {
                informationContent = context.InformationContent.Where(s => s.IsActive && !s.IsDeleted && s.CategoryId == categoryId).OrderBy(s => Guid.NewGuid()).Take(1).SingleOrDefault();
            }
            return informationContent;
        }

        public List<InformationContent> GetAllInformationContent()
        {
            List<InformationContent> informationContent = context.InformationContent.Where(s => s.IsActive && !s.IsDeleted).Include(s=>s.Author).Include(s=>s.Category).ToList();
            return informationContent;
        }
    }
}
