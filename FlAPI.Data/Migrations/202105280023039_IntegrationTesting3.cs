namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegrationTesting3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Armors", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Armors", new[] { "HistoryId" });
            AlterColumn("dbo.Armors", "HistoryId", c => c.Int());
            CreateIndex("dbo.Armors", "HistoryId");
            AddForeignKey("dbo.Armors", "HistoryId", "dbo.Histories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Armors", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Armors", new[] { "HistoryId" });
            AlterColumn("dbo.Armors", "HistoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Armors", "HistoryId");
            AddForeignKey("dbo.Armors", "HistoryId", "dbo.Histories", "Id", cascadeDelete: true);
        }
    }
}
