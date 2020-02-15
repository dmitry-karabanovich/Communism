using System.Data.Entity;
using Communism.Data.EntityFramework.DataBase.Configurations;
using Communism.Data.EntityFramework.DataBase.Entities;

namespace Communism.Data.EntityFramework.DataBase
{
    public class CommunismContext : DbContext
    {
        public CommunismContext() : base("CommunismDB")
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserDenunciation> UserDenunciations { get; set; }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Configurations.Add(new UserConfiguration());
            dbModelBuilder.Configurations.Add(new UserRoleConfiguration());
        }
    }
}
