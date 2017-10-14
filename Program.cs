using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book();
            book.BookId = 101;
            book.Title = "Cracking the code interview";
            book.Author = "Gayle Laakmann McDowell";
            book.PublishedYear = 2008;
            book.Quantity = 50;

            var account =  new Account();           // instantiate an object
            // account.AccountNumber = 1234;
            account.EmailAddress = "abc@xyz.com";
            //account.NumberOfBooksIssued = 20;

            var newBalance = account.Issue(5);

            Console.WriteLine($"AN: {account.AccountNumber}, EA: {account.EmailAddress}, Number of Books Issued: {account.NumberOfBooksIssued}");
        }

    }
}
