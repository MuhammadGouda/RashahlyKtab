namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Eventmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Description", c => c.String(maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "Description");
        }
    }
}
