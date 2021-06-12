namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M2MTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Species", "ListOfGames_Id", "dbo.Games");
            DropForeignKey("dbo.Games", "ListOfSpecies_Id", "dbo.Species");
            DropIndex("dbo.Games", new[] { "ListOfSpecies_Id" });
            DropIndex("dbo.Species", new[] { "ListOfGames_Id" });
            CreateTable(
                "dbo.SpeciesGames",
                c => new
                    {
                        Species_Id = c.Int(nullable: false),
                        Game_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Species_Id, t.Game_Id })
                .ForeignKey("dbo.Species", t => t.Species_Id, cascadeDelete: true)
                .ForeignKey("dbo.Games", t => t.Game_Id, cascadeDelete: true)
                .Index(t => t.Species_Id)
                .Index(t => t.Game_Id);
            
            DropColumn("dbo.Games", "ListOfSpecies_Id");
            DropColumn("dbo.Species", "ListOfGames_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Species", "ListOfGames_Id", c => c.Int());
            AddColumn("dbo.Games", "ListOfSpecies_Id", c => c.Int());
            DropForeignKey("dbo.SpeciesGames", "Game_Id", "dbo.Games");
            DropForeignKey("dbo.SpeciesGames", "Species_Id", "dbo.Species");
            DropIndex("dbo.SpeciesGames", new[] { "Game_Id" });
            DropIndex("dbo.SpeciesGames", new[] { "Species_Id" });
            DropTable("dbo.SpeciesGames");
            CreateIndex("dbo.Species", "ListOfGames_Id");
            CreateIndex("dbo.Games", "ListOfSpecies_Id");
            AddForeignKey("dbo.Games", "ListOfSpecies_Id", "dbo.Species", "Id");
            AddForeignKey("dbo.Species", "ListOfGames_Id", "dbo.Games", "Id");
        }
    }
}
