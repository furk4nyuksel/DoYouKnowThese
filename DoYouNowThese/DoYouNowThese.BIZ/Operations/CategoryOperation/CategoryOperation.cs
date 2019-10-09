using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DoYouNowThese.BIZ.Operations.CategoryOperation
{
   public class CategoryOperation
    {
        DoYouNowTheseContext context;

        public CategoryOperation(DoYouNowTheseContext _context)
        {
            context = _context;
        }

        public List<Category> GetAllCategoryList()
        {
            List<Category> categoryList = context.Category.Where(s => s.IsActive && !s.IsDeleted).ToList();
            return categoryList;
        }
    }
}
