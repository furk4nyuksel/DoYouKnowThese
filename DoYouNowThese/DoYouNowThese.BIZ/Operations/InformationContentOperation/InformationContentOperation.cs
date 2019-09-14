using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.BIZ.Operations.InformationContentOperation
{
   public class InformationContentOperation
    {
        DoYouNowTheseContext context;

        public InformationContentOperation(DoYouNowTheseContext _context)
        {
            context = _context;
        }
    }
}
