namespace Communism.Data.EntityFramework.DataBase
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeUserDenunciationtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDenunciation",
                c => new
                    {
                        Uid = c.Guid(nullable: false, identity: true, defaultValueSql: "newsequentialid()"),
                        Text = c.String(nullable: false),
                        DenunciationToUid = c.Guid(nullable: false),
                        InformerUid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Uid)
                .ForeignKey("dbo.User", t => t.DenunciationToUid, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.InformerUid, cascadeDelete: false)
                .Index(t => t.DenunciationToUid)
                .Index(t => t.InformerUid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDenunciations", "InformerUid", "dbo.User");
            DropForeignKey("dbo.UserDenunciations", "DenunciationToUid", "dbo.User");
            DropIndex("dbo.UserDenunciations", new[] { "InformerUid" });
            DropIndex("dbo.UserDenunciations", new[] { "DenunciationToUid" });
            DropTable("dbo.UserDenunciations");
        }
    }
}
