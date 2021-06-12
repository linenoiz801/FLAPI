namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableGameId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Armors", "GameId", "dbo.Games");
            DropIndex("dbo.Armors", new[] { "GameId" });
            AlterColumn("dbo.Armors", "GameId", c => c.Int());
            CreateIndex("dbo.Armors", "GameId");
            AddForeignKey("dbo.Armors", "GameId", "dbo.Games", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Armors", "GameId", "dbo.Games");
            DropIndex("dbo.Armors", new[] { "GameId" });
            AlterColumn("dbo.Armors", "GameId", c => c.Int(nullable: false));
            CreateIndex("dbo.Armors", "GameId");
            AddForeignKey("dbo.Armors", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
