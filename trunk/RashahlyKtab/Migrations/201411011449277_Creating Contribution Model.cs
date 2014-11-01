namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingContributionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsAtive = c.Boolean(nullable: false),
                        Title = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        CreateionDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EventModels");
        }
    }
}
