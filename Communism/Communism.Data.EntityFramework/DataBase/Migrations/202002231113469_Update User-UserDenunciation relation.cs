namespace Communism.Data.EntityFramework.DataBase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserUserDenunciationrelation : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserDenunciations", newName: "UserDenunciation");
            RenameColumn(table: "dbo.UserDenunciation", name: "DenunciationTo_Uid", newName: "DenunciationToUid");
            RenameColumn(table: "dbo.UserDenunciation", name: "Informer_Uid", newName: "InformerUid");
            RenameIndex(table: "dbo.UserDenunciation", name: "IX_Informer_Uid", newName: "IX_InformerUid");
            RenameIndex(table: "dbo.UserDenunciation", name: "IX_DenunciationTo_Uid", newName: "IX_DenunciationToUid");
            DropPrimaryKey("dbo.UserDenunciation");
            AlterColumn("dbo.UserDenunciation", "Uid", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.UserDenunciation", "Text", c => c.String(nullable: false));
            AddPrimaryKey("dbo.UserDenunciation", "Uid");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserDenunciation");
            AlterColumn("dbo.UserDenunciation", "Text", c => c.String());
            AlterColumn("dbo.UserDenunciation", "Uid", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserDenunciation", "Uid");
            RenameIndex(table: "dbo.UserDenunciation", name: "IX_DenunciationToUid", newName: "IX_DenunciationTo_Uid");
            RenameIndex(table: "dbo.UserDenunciation", name: "IX_InformerUid", newName: "IX_Informer_Uid");
            RenameColumn(table: "dbo.UserDenunciation", name: "InformerUid", newName: "Informer_Uid");
            RenameColumn(table: "dbo.UserDenunciation", name: "DenunciationToUid", newName: "DenunciationTo_Uid");
            RenameTable(name: "dbo.UserDenunciation", newName: "UserDenunciations");
        }
    }
}
