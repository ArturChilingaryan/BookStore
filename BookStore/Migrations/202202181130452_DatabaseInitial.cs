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
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        GenreId = c.Int(),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("dbo.Genre", t => t.GenreId)
                .Index(t => t.GenreId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Genre",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                        PriceDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.BranchID);
            
            CreateTable(
                "dbo.Branches",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Sum = c.Double(),
                        TypeOfMovement = c.Int(nullable: false),
                        MovementDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.BranchId);
            
            CreateTable(
                "dbo.Balance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookID = c.Int(nullable: false),
                        BranchID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TypeOfMovement = c.Int(nullable: false),
                        MovementDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Books", t => t.BookID, cascadeDelete: true)
                .ForeignKey("dbo.Branches", t => t.BranchID, cascadeDelete: true)
                .Index(t => t.BookID)
                .Index(t => t.BranchID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Balance", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Balance", "BookID", "dbo.Books");
            DropForeignKey("dbo.Sales", "BranchId", "dbo.Branches");
            DropForeignKey("dbo.Sales", "BookId", "dbo.Books");
            DropForeignKey("dbo.Prices", "BranchID", "dbo.Branches");
            DropForeignKey("dbo.Prices", "BookID", "dbo.Books");
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genre");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Balance", new[] { "BranchID" });
            DropIndex("dbo.Balance", new[] { "BookID" });
            DropIndex("dbo.Sales", new[] { "BranchId" });
            DropIndex("dbo.Sales", new[] { "BookId" });
            DropIndex("dbo.Prices", new[] { "BranchID" });
            DropIndex("dbo.Prices", new[] { "BookID" });
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropTable("dbo.Balance");
            DropTable("dbo.Sales");
            DropTable("dbo.Branches");
            DropTable("dbo.Prices");
            DropTable("dbo.Genre");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
        }
    }
}
