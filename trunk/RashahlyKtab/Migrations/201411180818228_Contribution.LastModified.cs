namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContributionLastModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "LastModified", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contributors", "LastModified");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributors", "LastModified", c => c.DateTime(nullable: false));
            DropColumn("dbo.Contributions", "LastModified");
        }
    }
}
