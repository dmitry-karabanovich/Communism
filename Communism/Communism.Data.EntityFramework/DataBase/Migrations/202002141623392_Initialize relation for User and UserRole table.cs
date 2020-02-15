namespace Communism.Data.EntityFramework.DataBase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializerelationforUserandUserRoletable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "Role_Uid", c => c.Guid(nullable: false));
            CreateIndex("dbo.User", "Role_Uid");
            AddForeignKey("dbo.User", "Role_Uid", "dbo.UserRole", "Uid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "Role_Uid", "dbo.UserRole");
            DropIndex("dbo.User", new[] { "Role_Uid" });
            DropColumn("dbo.User", "Role_Uid");
        }
    }
}
