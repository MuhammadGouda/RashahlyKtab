namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingWeek : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Weeks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        StartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Weeks");
        }
    }
}
