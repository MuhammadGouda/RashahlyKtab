namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatingWeek : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Weeks", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Weeks", "Name", c => c.String());
        }
    }
}
