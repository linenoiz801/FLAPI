namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Armors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Prereq = c.String(),
                        Description = c.String(),
                        GameId = c.Int(nullable: false),
                        HistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Histories", t => t.HistoryId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.HistoryId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameName = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        ListOfSpecies_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Species", t => t.ListOfSpecies_Id)
                .Index(t => t.ListOfSpecies_Id);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameName = c.String(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        ListOfGames_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.ListOfGames_Id)
                .Index(t => t.ListOfGames_Id);
            
            CreateTable(
                "dbo.Histories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        EventDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        GameId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        Affiliation = c.String(nullable: false),
                        IsNPC = c.Boolean(nullable: false),
                        IsHostile = c.Boolean(nullable: false),
                        SpeciesId = c.Int(nullable: false),
                        GameId = c.Int(nullable: false),
                        HistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Histories", t => t.HistoryId, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.SpeciesId, cascadeDelete: true)
                .Index(t => t.SpeciesId)
                .Index(t => t.GameId)
                .Index(t => t.HistoryId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        MetroArea = c.String(),
                        Country = c.String(),
                        GameId = c.Int(nullable: false),
                        HistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Histories", t => t.HistoryId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.HistoryId);
            
            CreateTable(
                "dbo.Perks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Prereq = c.String(),
                        Description = c.String(),
                        GameId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Vaults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VaultName = c.String(nullable: false),
                        VaultNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Weapons",
                c => new
                    {
                        WeaponId = c.Int(nullable: false, identity: true),
                        WeaponName = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        AmmoType = c.String(),
                        WeaponType = c.String(nullable: false),
                        BaseDamage = c.String(),
                        GameId = c.Int(nullable: false),
                        HistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WeaponId)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .ForeignKey("dbo.Histories", t => t.HistoryId, cascadeDelete: true)
                .Index(t => t.GameId)
                .Index(t => t.HistoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Weapons", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Weapons", "GameId", "dbo.Games");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Perks", "GameId", "dbo.Games");
            DropForeignKey("dbo.Locations", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Locations", "GameId", "dbo.Games");
            DropForeignKey("dbo.Characters", "SpeciesId", "dbo.Species");
            DropForeignKey("dbo.Characters", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Characters", "GameId", "dbo.Games");
            DropForeignKey("dbo.Armors", "HistoryId", "dbo.Histories");
            DropForeignKey("dbo.Histories", "GameId", "dbo.Games");
            DropForeignKey("dbo.Armors", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "ListOfSpecies_Id", "dbo.Species");
            DropForeignKey("dbo.Species", "ListOfGames_Id", "dbo.Games");
            DropIndex("dbo.Weapons", new[] { "HistoryId" });
            DropIndex("dbo.Weapons", new[] { "GameId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Perks", new[] { "GameId" });
            DropIndex("dbo.Locations", new[] { "HistoryId" });
            DropIndex("dbo.Locations", new[] { "GameId" });
            DropIndex("dbo.Characters", new[] { "HistoryId" });
            DropIndex("dbo.Characters", new[] { "GameId" });
            DropIndex("dbo.Characters", new[] { "SpeciesId" });
            DropIndex("dbo.Histories", new[] { "GameId" });
            DropIndex("dbo.Species", new[] { "ListOfGames_Id" });
            DropIndex("dbo.Games", new[] { "ListOfSpecies_Id" });
            DropIndex("dbo.Armors", new[] { "HistoryId" });
            DropIndex("dbo.Armors", new[] { "GameId" });
            DropTable("dbo.Weapons");
            DropTable("dbo.Vaults");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Perks");
            DropTable("dbo.Locations");
            DropTable("dbo.Characters");
            DropTable("dbo.Histories");
            DropTable("dbo.Species");
            DropTable("dbo.Games");
            DropTable("dbo.Armors");
        }
    }
}
