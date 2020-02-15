using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Communism.Data.EntityFramework.DataBase.Entities;

namespace Communism.Data.EntityFramework.DataBase.Configurations
{
    public class UserDenunciationConfiguration : EntityTypeConfiguration<UserDenunciation>
    {
        public UserDenunciationConfiguration()
        {
            ToTable("UserDenunciation");
            HasKey(x => x.Uid);
            Property(x => x.Uid).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Text).IsRequired();
//            HasRequired(x => x.Informer)
//                .WithMany(x => x.OwnDenunciations);
//
//            HasRequired(x => x.DenunciationTo)
//                .WithMany(x => x.DenunciationsToThisUser);
        }
    }
}
