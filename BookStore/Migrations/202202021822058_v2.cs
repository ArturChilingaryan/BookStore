namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AuthorInfoes", newName: "Authors");
            AlterColumn("dbo.Authors", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Name", c => c.String());
            RenameTable(name: "dbo.Authors", newName: "AuthorInfoes");
        }
    }
}
