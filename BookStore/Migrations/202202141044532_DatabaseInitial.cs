namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.BookInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Author_ID = c.Int(),
                        Genre_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.Author_ID)
                .ForeignKey("dbo.BookGenres", t => t.Genre_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Genre_ID);
            
            CreateTable(
                "dbo.BookPrices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        PriceDateTime = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                        Branch_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookInfoes", t => t.Book_Id)
                .ForeignKey("dbo.BranchInfoes", t => t.Branch_ID)
                .Index(t => t.Book_Id)
                .Index(t => t.Branch_ID);
            
            CreateTable(
                "dbo.BranchInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Sum = c.Double(nullable: false),
                        TypeOfMovement = c.Int(nullable: false),
                        MovementDate = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                        Branch_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookInfoes", t => t.Book_Id)
                .ForeignKey("dbo.BranchInfoes", t => t.Branch_ID)
                .Index(t => t.Book_Id)
                .Index(t => t.Branch_ID);
            
            CreateTable(
                "dbo.StockBalances",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        TypeOfMovement = c.Int(nullable: false),
                        MovementDate = c.DateTime(nullable: false),
                        Book_Id = c.Int(),
                        Branch_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.BookInfoes", t => t.Book_Id)
                .ForeignKey("dbo.BranchInfoes", t => t.Branch_ID)
                .Index(t => t.Book_Id)
                .Index(t => t.Branch_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockBalances", "Branch_ID", "dbo.BranchInfoes");
            DropForeignKey("dbo.StockBalances", "Book_Id", "dbo.BookInfoes");
            DropForeignKey("dbo.Sales", "Branch_ID", "dbo.BranchInfoes");
            DropForeignKey("dbo.Sales", "Book_Id", "dbo.BookInfoes");
            DropForeignKey("dbo.BookPrices", "Branch_ID", "dbo.BranchInfoes");
            DropForeignKey("dbo.BookPrices", "Book_Id", "dbo.BookInfoes");
            DropForeignKey("dbo.BookInfoes", "Genre_ID", "dbo.BookGenres");
            DropForeignKey("dbo.BookInfoes", "Author_ID", "dbo.Authors");
            DropIndex("dbo.StockBalances", new[] { "Branch_ID" });
            DropIndex("dbo.StockBalances", new[] { "Book_Id" });
            DropIndex("dbo.Sales", new[] { "Branch_ID" });
            DropIndex("dbo.Sales", new[] { "Book_Id" });
            DropIndex("dbo.BookPrices", new[] { "Branch_ID" });
            DropIndex("dbo.BookPrices", new[] { "Book_Id" });
            DropIndex("dbo.BookInfoes", new[] { "Genre_ID" });
            DropIndex("dbo.BookInfoes", new[] { "Author_ID" });
            DropTable("dbo.StockBalances");
            DropTable("dbo.Sales");
            DropTable("dbo.BranchInfoes");
            DropTable("dbo.BookPrices");
            DropTable("dbo.BookInfoes");
            DropTable("dbo.BookGenres");
            DropTable("dbo.Authors");
        }
    }
}
