namespace Communism.Data.EntityFramework.DataBase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializerelationforUserandUserRoletable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "RoleUid", c => c.Guid(nullable: false));
            CreateIndex("dbo.User", "RoleUid");
            AddForeignKey("dbo.User", "RoleUid", "dbo.UserRole", "Uid", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "RoleUid", "dbo.UserRole");
            DropIndex("dbo.User", new[] { "RoleUid" });
            DropColumn("dbo.User", "Role_Uid");
        }
    }
}
