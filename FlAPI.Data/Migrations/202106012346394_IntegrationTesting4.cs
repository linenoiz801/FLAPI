﻿namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegrationTesting4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Armors", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Locations", "GameId", "dbo.Games");
            DropForeignKey("dbo.Locations", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Armors", new[] { "HistoryId" });
            DropIndex("dbo.Locations", new[] { "GameId" });
            DropIndex("dbo.Locations", new[] { "HistoryId" });
            AlterColumn("dbo.Armors", "HistoryId", c => c.Int());
            AlterColumn("dbo.Locations", "GameId", c => c.Int());
            AlterColumn("dbo.Locations", "HistoryId", c => c.Int());
            CreateIndex("dbo.Armors", "HistoryId");
            CreateIndex("dbo.Locations", "GameId");
            CreateIndex("dbo.Locations", "HistoryId");
            AddForeignKey("dbo.Armors", "HistoryId", "dbo.Histories", "Id");
            AddForeignKey("dbo.Locations", "GameId", "dbo.Games", "Id");
            AddForeignKey("dbo.Locations", "HistoryId", "dbo.Histories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Locations", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Locations", "GameId", "dbo.Games");
            DropForeignKey("dbo.Armors", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Locations", new[] { "HistoryId" });
            DropIndex("dbo.Locations", new[] { "GameId" });
            DropIndex("dbo.Armors", new[] { "HistoryId" });
            AlterColumn("dbo.Locations", "HistoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Locations", "GameId", c => c.Int(nullable: false));
            AlterColumn("dbo.Armors", "HistoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Locations", "HistoryId");
            CreateIndex("dbo.Locations", "GameId");
            CreateIndex("dbo.Armors", "HistoryId");
            AddForeignKey("dbo.Locations", "HistoryId", "dbo.Histories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Locations", "GameId", "dbo.Games", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Armors", "HistoryId", "dbo.Histories", "Id", cascadeDelete: true);
        }
    }
}
