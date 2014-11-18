namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContributionLastModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributors", "LastModified", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contributors", "LastModified");
        }
    }
}
