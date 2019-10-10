using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.BIZ.Operations.ErrorEntityOperation
{
   public class ErrorEntityOperation
    {
        DoYouNowTheseContext context;

        public ErrorEntityOperation(DoYouNowTheseContext _context)
        {
            context = _context;
        }

        public void Insert(ErrorEntity entity)
        {
            context.ErrorEntity.Add(entity);
            context.SaveChanges();
        }

    }
}
