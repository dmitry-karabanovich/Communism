using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Communism.Data.EntityFramework.DataBase.Entities;

namespace Communism.Data.EntityFramework.DataBase.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("User");
            HasKey(x => x.Uid);
            Property(x => x.Uid).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UserName).IsRequired();
            Property(x => x.FirstName).IsRequired();
            Property(x => x.LastName).IsRequired();

            HasMany(x => x.OwnDenunciations)
                .WithRequired(x => x.Informer)
                .HasForeignKey(x => x.InformerUid);
            HasMany(x => x.DenunciationsToThisUser)
                .WithRequired(x => x.DenunciationTo)
                .HasForeignKey(x => x.DenunciationToUid);
        }
    }
}
