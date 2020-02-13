using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Communism.Data.EntityFramework.DataBase.Entities;

namespace Communism.Data.EntityFramework.DataBase.Configurations
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            ToTable("UserRole");
            HasKey(x => x.Uid);
            Property(x => x.Uid).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).IsRequired();
        }
    }
}
