namespace FLAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adrianna2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Characters", "Affiliation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Characters", "Affiliation", c => c.String(nullable: false));
        }
    }
}
