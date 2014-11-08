namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeContributionEndDatenullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contributions", "EndtDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contributions", "EndtDate", c => c.DateTime(nullable: false));
        }
    }
}
