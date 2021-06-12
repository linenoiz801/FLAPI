namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adrianna1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Weapons", "GameId", "dbo.Games");
            DropForeignKey("dbo.Weapons", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Weapons", new[] { "GameId" });
            DropIndex("dbo.Weapons", new[] { "HistoryId" });
            AlterColumn("dbo.Weapons", "GameId", c => c.Int());
            AlterColumn("dbo.Weapons", "HistoryId", c => c.Int());
            CreateIndex("dbo.Weapons", "GameId");
            CreateIndex("dbo.Weapons", "HistoryId");
            AddForeignKey("dbo.Weapons", "GameId", "dbo.Games", "Id");
            AddForeignKey("dbo.Weapons", "HistoryId", "dbo.Histories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Weapons", "GameId", "dbo.Games");
            DropIndex("dbo.Weapons", new[] { "HistoryId" });
            DropIndex("dbo.Weapons", new[] { "GameId" });
            AlterColumn("dbo.Weapons", "HistoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Weapons", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Weapons", "HistoryId");
            CreateIndex("dbo.Weapons", "GameId");
            AddForeignKey("dbo.Weapons", "HistoryId", "dbo.Histories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Weapons", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
