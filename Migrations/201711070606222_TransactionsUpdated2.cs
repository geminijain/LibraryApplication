namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TransactionsUpdated2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "NumberOfBooks", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "NumberOfBooks");
        }
    }
}
