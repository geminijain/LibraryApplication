namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Transactions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        TypeOfTransaction = c.Int(nullable: false),
                        AccountNumber = c.Int(nullable: false),
                        BookNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Accounts", t => t.AccountNumber, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookNumber, cascadeDelete: true)
                .Index(t => t.AccountNumber)
                .Index(t => t.BookNumber);
            
            AddColumn("dbo.Books", "BookAddedOn", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "BookNumber", "dbo.Books");
            DropForeignKey("dbo.Transactions", "AccountNumber", "dbo.Accounts");
            DropIndex("dbo.Transactions", new[] { "BookNumber" });
            DropIndex("dbo.Transactions", new[] { "AccountNumber" });
            DropColumn("dbo.Books", "BookAddedOn");
            DropTable("dbo.Transactions");
        }
    }
}
