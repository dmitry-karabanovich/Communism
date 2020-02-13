using System;

namespace Communism.Data.EntityFramework.DataBase.Entities
{
    public class User
    {
        public Guid Uid { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
