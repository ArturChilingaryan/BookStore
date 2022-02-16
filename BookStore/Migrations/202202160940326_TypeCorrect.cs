namespace BookStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TypeCorrect : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BranchInfoes", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BranchInfoes", "Name", c => c.Int(nullable: false));
        }
    }
}
