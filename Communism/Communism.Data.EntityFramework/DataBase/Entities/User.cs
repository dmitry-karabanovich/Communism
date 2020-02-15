using System;
using System.Collections.Generic;

namespace Communism.Data.EntityFramework.DataBase.Entities
{
    public class User
    {
        public Guid Uid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual UserRole Role { get; set; }
        public virtual ICollection<UserDenunciation> OwnDenunciations { get; set; }
        public virtual ICollection<UserDenunciation> DenunciationsToThisUser { get; set; }
    }
}
