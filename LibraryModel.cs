namespace LibraryApp
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LibraryModel : DbContext
    {
        // Your context has been configured to use a 'LibraryModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LibraryApp.LibraryModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'LibraryModel' 
        // connection string in the application configuration file.
        public LibraryModel()
            : base("name=LibraryModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Book> Books { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}