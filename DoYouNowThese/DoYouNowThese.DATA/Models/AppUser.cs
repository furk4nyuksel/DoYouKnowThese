using System;
using System.Collections.Generic;

namespace DoYouNowThese.DATA.Models
{
    public partial class AppUser
    {
        public AppUser()
        {
            ErrorEntity = new HashSet<ErrorEntity>();
            InformationContent = new HashSet<InformationContent>();
            InformationReadLog = new HashSet<InformationReadLog>();
            LogEntity = new HashSet<LogEntity>();
        }

        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ResetKeyCode { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public ICollection<ErrorEntity> ErrorEntity { get; set; }
        public ICollection<InformationContent> InformationContent { get; set; }
        public ICollection<InformationReadLog> InformationReadLog { get; set; }
        public ICollection<LogEntity> LogEntity { get; set; }
    }
}
