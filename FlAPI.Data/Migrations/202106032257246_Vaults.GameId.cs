namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VaultsGameId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vaults", "GameId", c => c.Int());
            CreateIndex("dbo.Vaults", "GameId");
            AddForeignKey("dbo.Vaults", "GameId", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vaults", "GameId", "dbo.Games");
            DropIndex("dbo.Vaults", new[] { "GameId" });
            DropColumn("dbo.Vaults", "GameId");
        }
    }
}
