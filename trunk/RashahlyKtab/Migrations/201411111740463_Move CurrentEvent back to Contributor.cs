namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveCurrentEventbacktoContributor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributions", "CurrentEvent_Id", "dbo.Events");
            DropIndex("dbo.Contributions", new[] { "CurrentEvent_Id" });
            AddColumn("dbo.Contributors", "CurrentEvent_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Contributors", "CurrentEvent_Id");
            AddForeignKey("dbo.Contributors", "CurrentEvent_Id", "dbo.Events", "Id", cascadeDelete: true);
            DropColumn("dbo.Contributions", "CurrentEvent_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contributions", "CurrentEvent_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Contributors", "CurrentEvent_Id", "dbo.Events");
            DropIndex("dbo.Contributors", new[] { "CurrentEvent_Id" });
            DropColumn("dbo.Contributors", "CurrentEvent_Id");
            CreateIndex("dbo.Contributions", "CurrentEvent_Id");
            AddForeignKey("dbo.Contributions", "CurrentEvent_Id", "dbo.Events", "Id", cascadeDelete: true);
        }
    }
}
