using System;
using System.Collections.Generic;

namespace Communism.Data.EntityFramework.DataBase.Entities
{
    public class UserRole
    {
        public Guid Uid { get; set; }
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
