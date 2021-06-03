namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Testing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "GameId", "dbo.Games");
            DropForeignKey("dbo.Locations", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Locations", new[] { "GameId" });
            DropIndex("dbo.Locations", new[] { "HistoryId" });
            AlterColumn("dbo.Locations", "GameId", c => c.Int());
            AlterColumn("dbo.Locations", "HistoryId", c => c.Int());
            CreateIndex("dbo.Locations", "GameId");
            CreateIndex("dbo.Locations", "HistoryId");
            AddForeignKey("dbo.Locations", "GameId", "dbo.Games", "Id");
            AddForeignKey("dbo.Locations", "HistoryId", "dbo.Histories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Locations", "GameId", "dbo.Games");
            DropIndex("dbo.Locations", new[] { "HistoryId" });
            DropIndex("dbo.Locations", new[] { "GameId" });
            AlterColumn("dbo.Locations", "HistoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "HistoryId");
            CreateIndex("dbo.Locations", "GameId");
            AddForeignKey("dbo.Locations", "HistoryId", "dbo.Histories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
