namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectingContributionModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.EventModels", newName: "Events");
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PagesCount = c.Int(nullable: false),
                        ReviewURL = c.String(),
                        ImageURL = c.String(),
                        BookURL = c.String(),
                        CurrentPage = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndtDate = c.DateTime(nullable: false),
                        Book_Id = c.Int(nullable: false),
                        Contributer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contributors", t => t.Contributer_Id, cascadeDelete: true)
                .Index(t => t.Book_Id)
                .Index(t => t.Contributer_Id);
            
            CreateTable(
                "dbo.Contributors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JoinDate = c.DateTime(nullable: false),
                        Points = c.Int(nullable: false),
                        CurrentEvent_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.CurrentEvent_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.CurrentEvent_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributions", "Contributer_Id", "dbo.Contributors");
            DropForeignKey("dbo.Contributors", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Contributors", "CurrentEvent_Id", "dbo.Events");
            DropForeignKey("dbo.Contributions", "Book_Id", "dbo.Books");
            DropIndex("dbo.Contributors", new[] { "User_Id" });
            DropIndex("dbo.Contributors", new[] { "CurrentEvent_Id" });
            DropIndex("dbo.Contributions", new[] { "Contributer_Id" });
            DropIndex("dbo.Contributions", new[] { "Book_Id" });
            DropTable("dbo.Contributors");
            DropTable("dbo.Contributions");
            DropTable("dbo.Books");
            RenameTable(name: "dbo.Events", newName: "EventModels");
        }
    }
}
