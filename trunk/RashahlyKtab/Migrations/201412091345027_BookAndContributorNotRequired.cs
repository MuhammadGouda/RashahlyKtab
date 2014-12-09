namespace RashahlyKtab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAndContributorNotRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contributions", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.Contributions", "Contributer_Id", "dbo.Contributors");
            DropIndex("dbo.Contributions", new[] { "Book_Id" });
            DropIndex("dbo.Contributions", new[] { "Contributer_Id" });
            AlterColumn("dbo.Contributions", "Book_Id", c => c.Int());
            AlterColumn("dbo.Contributions", "Contributer_Id", c => c.Int());
            CreateIndex("dbo.Contributions", "Book_Id");
            CreateIndex("dbo.Contributions", "Contributer_Id");
            AddForeignKey("dbo.Contributions", "Book_Id", "dbo.Books", "Id");
            AddForeignKey("dbo.Contributions", "Contributer_Id", "dbo.Contributors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contributions", "Contributer_Id", "dbo.Contributors");
            DropForeignKey("dbo.Contributions", "Book_Id", "dbo.Books");
            DropIndex("dbo.Contributions", new[] { "Contributer_Id" });
            DropIndex("dbo.Contributions", new[] { "Book_Id" });
            AlterColumn("dbo.Contributions", "Contributer_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Contributions", "Book_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Contributions", "Contributer_Id");
            CreateIndex("dbo.Contributions", "Book_Id");
            AddForeignKey("dbo.Contributions", "Contributer_Id", "dbo.Contributors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Contributions", "Book_Id", "dbo.Books", "Id", cascadeDelete: true);
        }
    }
}
