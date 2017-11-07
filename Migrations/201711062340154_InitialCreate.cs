namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        AccountNumber = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        NumberOfIssuedBooks = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccountNumber);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookNumber = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookNumber);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Books");
            DropTable("dbo.Accounts");
        }
    }
}
