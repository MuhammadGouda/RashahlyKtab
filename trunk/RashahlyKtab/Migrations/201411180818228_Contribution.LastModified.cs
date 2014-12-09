namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ContributionLastModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contributions", "LastModified", c => c.DateTime(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Contributions", "LastModified");
        }
    }
}
