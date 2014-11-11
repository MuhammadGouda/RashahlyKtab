namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveCurrentEventfromContributortoContribution : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributors", "CurrentEvent_Id", "dbo.Events");
            DropIndex("dbo.Contributors", new[] { "CurrentEvent_Id" });
            AddColumn("dbo.Contributions", "CurrentEvent_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Contributions", "CurrentEvent_Id");
            AddForeignKey("dbo.Contributions", "CurrentEvent_Id", "dbo.Events", "Id", cascadeDelete: true);
            DropColumn("dbo.Contributors", "CurrentEvent_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributors", "CurrentEvent_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contributions", "CurrentEvent_Id", "dbo.Events");
            DropIndex("dbo.Contributions", new[] { "CurrentEvent_Id" });
            DropColumn("dbo.Contributions", "CurrentEvent_Id");
            CreateIndex("dbo.Contributors", "CurrentEvent_Id");
            AddForeignKey("dbo.Contributors", "CurrentEvent_Id", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
