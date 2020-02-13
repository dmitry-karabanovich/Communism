using System.Data.Entity.Migrations;

namespace Communism.Data.EntityFramework.DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Communism.Data.EntityFramework.DataBase.CommunismContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataBase/Migrations";
        }

        protected override void Seed(Communism.Data.EntityFramework.DataBase.CommunismContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
