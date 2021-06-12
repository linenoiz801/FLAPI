namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntegrationTesting2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "GameId", "dbo.Games");
            DropForeignKey("dbo.Characters", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Characters", "SpeciesId", "dbo.Species");
            DropIndex("dbo.Characters", new[] { "SpeciesId" });
            DropIndex("dbo.Characters", new[] { "GameId" });
            DropIndex("dbo.Characters", new[] { "HistoryId" });
            CreateTable(
                "dbo.LocationCharacters",
                c => new
                    {
                        Location_Id = c.Int(nullable: false),
                        Character_CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Location_Id, t.Character_CharacterId })
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.Character_CharacterId, cascadeDelete: true)
                .Index(t => t.Location_Id)
                .Index(t => t.Character_CharacterId);
            
            CreateTable(
                "dbo.VaultCharacters",
                c => new
                    {
                        Vault_Id = c.Int(nullable: false),
                        Character_CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vault_Id, t.Character_CharacterId })
                .ForeignKey("dbo.Vaults", t => t.Vault_Id, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.Character_CharacterId, cascadeDelete: true)
                .Index(t => t.Vault_Id)
                .Index(t => t.Character_CharacterId);
            
            AlterColumn("dbo.Characters", "SpeciesId", c => c.Int());
            AlterColumn("dbo.Characters", "GameId", c => c.Int());
            AlterColumn("dbo.Characters", "HistoryId", c => c.Int());
            CreateIndex("dbo.Characters", "SpeciesId");
            CreateIndex("dbo.Characters", "GameId");
            CreateIndex("dbo.Characters", "HistoryId");
            AddForeignKey("dbo.Characters", "GameId", "dbo.Games", "Id");
            AddForeignKey("dbo.Characters", "HistoryId", "dbo.Histories", "Id");
            AddForeignKey("dbo.Characters", "SpeciesId", "dbo.Species", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Characters", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Characters", "GameId", "dbo.Games");
            DropForeignKey("dbo.VaultCharacters", "Character_CharacterId", "dbo.Characters");
            DropForeignKey("dbo.VaultCharacters", "Vault_Id", "dbo.Vaults");
            DropForeignKey("dbo.LocationCharacters", "Character_CharacterId", "dbo.Characters");
            DropForeignKey("dbo.LocationCharacters", "Location_Id", "dbo.Locations");
            DropIndex("dbo.VaultCharacters", new[] { "Character_CharacterId" });
            DropIndex("dbo.VaultCharacters", new[] { "Vault_Id" });
            DropIndex("dbo.LocationCharacters", new[] { "Character_CharacterId" });
            DropIndex("dbo.LocationCharacters", new[] { "Location_Id" });
            DropIndex("dbo.Characters", new[] { "HistoryId" });
            DropIndex("dbo.Characters", new[] { "GameId" });
            DropIndex("dbo.Characters", new[] { "SpeciesId" });
            AlterColumn("dbo.Characters", "HistoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Characters", "GameId", c => c.Int(nullable: false));
            AlterColumn("dbo.Characters", "SpeciesId", c => c.Int(nullable: false));
            DropTable("dbo.VaultCharacters");
            DropTable("dbo.LocationCharacters");
            CreateIndex("dbo.Characters", "HistoryId");
            CreateIndex("dbo.Characters", "GameId");
            CreateIndex("dbo.Characters", "SpeciesId");
            AddForeignKey("dbo.Characters", "SpeciesId", "dbo.Species", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Characters", "HistoryId", "dbo.Histories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Characters", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
