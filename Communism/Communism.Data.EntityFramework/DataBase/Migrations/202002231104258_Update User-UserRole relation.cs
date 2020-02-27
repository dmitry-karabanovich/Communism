namespace Communism.Data.EntityFramework.DataBase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserUserRolerelation : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.User", name: "Role_Uid", newName: "RoleUid");
            RenameIndex(table: "dbo.User", name: "IX_Role_Uid", newName: "IX_RoleUid");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.User", name: "IX_RoleUid", newName: "IX_Role_Uid");
            RenameColumn(table: "dbo.User", name: "RoleUid", newName: "Role_Uid");
        }
    }
}
