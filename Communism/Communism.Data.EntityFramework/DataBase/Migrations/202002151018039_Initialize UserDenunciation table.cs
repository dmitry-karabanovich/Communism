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
                        DenunciationTo_Uid = c.Guid(nullable: false),
                        Informer_Uid = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Uid)
                .ForeignKey("dbo.User", t => t.DenunciationTo_Uid, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.Informer_Uid, cascadeDelete: false)
                .Index(t => t.DenunciationTo_Uid)
                .Index(t => t.Informer_Uid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDenunciations", "Informer_Uid", "dbo.User");
            DropForeignKey("dbo.UserDenunciations", "DenunciationTo_Uid", "dbo.User");
            DropIndex("dbo.UserDenunciations", new[] { "Informer_Uid" });
            DropIndex("dbo.UserDenunciations", new[] { "DenunciationTo_Uid" });
            DropTable("dbo.UserDenunciations");
        }
    }
}
