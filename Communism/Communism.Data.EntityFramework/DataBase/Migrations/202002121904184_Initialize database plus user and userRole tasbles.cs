namespace Communism.Data.EntityFramework.DataBase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializedatabaseplususeranduserRoletasbles : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        Uid = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Uid);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Uid = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        UserName = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Uid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
        }
    }
}
