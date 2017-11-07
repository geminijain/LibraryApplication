using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public static class Library
    {
        private static LibraryModel db = new LibraryModel();

    /// <summary>
    /// Library creates an account for user
    /// </summary>
    /// <param name="emailAddress">Email address of the account</param> 
    /// <returns>return new account</returns>
    /// 


        public static Account CreateAccount(string emailAddress)
        {
            var account = new Account
            { EmailAddress = emailAddress
            };
            db.Accounts.Add(account);
            db.SaveChanges();
            Console.WriteLine("Account has been created !");
            return account;   
        }

        public static Book AddBook(string bookTitle, int bookQuantity)
        {
            var book = new Book {
                Title = bookTitle, 
                Quantity = bookQuantity };
            db.Books.Add(book);
            db.SaveChanges();
            Console.WriteLine("Book has been added to library !");
            return book;
        }

        public static List<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

    }
}
