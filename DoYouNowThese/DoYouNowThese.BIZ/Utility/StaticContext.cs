using DoYouNowThese.DATA.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoYouNowThese.BIZ.Utility
{
    public static class StaticContext
    {
       public static DoYouNowTheseContext context;

        private static DoYouNowTheseContext _context;

       
        public static DoYouNowTheseContext GetInstance()
        {
            if (context == null)
            {
                _context = new DoYouNowTheseContext();
                context = _context;
            }
            return context;
        }
    }
}
