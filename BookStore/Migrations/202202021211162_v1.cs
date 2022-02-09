namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                .ForeignKey("dbo.AuthorInfoes", t => t.Author_ID)
                .ForeignKey("dbo.BookGenres", t => t.Genre_ID)
                .Index(t => t.Author_ID)
                .Index(t => t.Genre_ID);
            
            CreateTable(
                "dbo.BranchInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookInfoes", "Genre_ID", "dbo.BookGenres");
            DropForeignKey("dbo.BookInfoes", "Author_ID", "dbo.AuthorInfoes");
            DropIndex("dbo.BookInfoes", new[] { "Genre_ID" });
            DropIndex("dbo.BookInfoes", new[] { "Author_ID" });
            DropTable("dbo.BranchInfoes");
            DropTable("dbo.BookInfoes");
            DropTable("dbo.BookGenres");
            DropTable("dbo.AuthorInfoes");
        }
    }
}
