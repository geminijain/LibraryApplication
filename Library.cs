using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public static class Library
    {
        private static List<Account> accounts = new List<Account>();
        private static List<Book> books = new List<Book>();

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
            accounts.Add(account);
            Console.WriteLine("Account has been created !");
            return account;   
            
        }

        public static Book AddBook(string bookTitle, int bookQuantity)
        {
            var book = new Book {
                Title = bookTitle, 
                Quantity = bookQuantity };
            books.Add(book);
            Console.WriteLine("Book has been added !");
            return book;
        }

        public static List<Book> GetAllBooks()
        {
            return books;
        }

    }
}
