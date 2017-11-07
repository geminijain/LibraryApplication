namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "TransactionDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.Transactions", "TransactionDate");
        }
    }
}
