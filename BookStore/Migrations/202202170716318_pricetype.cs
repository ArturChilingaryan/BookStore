namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pricetype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookPrices", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.BookPrices", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookPrices", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.BookPrices", "Price");
        }
    }
}
