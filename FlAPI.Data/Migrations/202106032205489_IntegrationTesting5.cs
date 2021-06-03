namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegrationTesting5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Species", "SpeciesName", c => c.String(nullable: false));
            AddColumn("dbo.Species", "Weakness", c => c.String(nullable: false));
            AddColumn("dbo.Species", "Strength", c => c.String());
            AddColumn("dbo.Species", "HistoryId", c => c.Int());
            AddColumn("dbo.Vaults", "LocationId", c => c.Int());
            CreateIndex("dbo.Species", "HistoryId");
            CreateIndex("dbo.Vaults", "LocationId");
            AddForeignKey("dbo.Species", "HistoryId", "dbo.Histories", "Id");
            AddForeignKey("dbo.Vaults", "LocationId", "dbo.Locations", "Id");
            DropColumn("dbo.Species", "GameName");
            DropColumn("dbo.Species", "ReleaseDate");
            DropColumn("dbo.Species", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Species", "Description", c => c.String());
            AddColumn("dbo.Species", "ReleaseDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Species", "GameName", c => c.String(nullable: false));
            DropForeignKey("dbo.Vaults", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Species", "HistoryId", "dbo.Histories");
            DropIndex("dbo.Vaults", new[] { "LocationId" });
            DropIndex("dbo.Species", new[] { "HistoryId" });
            DropColumn("dbo.Vaults", "LocationId");
            DropColumn("dbo.Species", "HistoryId");
            DropColumn("dbo.Species", "Strength");
            DropColumn("dbo.Species", "Weakness");
            DropColumn("dbo.Species", "SpeciesName");
        }
    }
}
