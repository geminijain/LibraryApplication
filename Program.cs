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
            Console.WriteLine("************************");
            Console.WriteLine("Welcome to my Library");
            Console.WriteLine("***************************");
            while (true) {
                Console.WriteLine("Please choose an option below:");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account"); 
                Console.WriteLine("2. Issue a book");
                Console.WriteLine("3. Deposit a book");
                Console.WriteLine("4. Print all issued books");
                Console.WriteLine("5. Print all transactions");
                Console.WriteLine("6. Print all books in library");
                Console.WriteLine("7. Add a book to library");

                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":
                        return;

                    case "1":
                        Console.Write("Email Address: ");
                        var emailAddress = Console.ReadLine();
                        var account = Library.CreateAccount(emailAddress);
                        Console.WriteLine($"AN: {account.AccountNumber}, Number of issued books:{account.NumberOfIssuedBooks}, created dated : {account.CreatedDate}");
                        break;

                    case "2":
                        Console.Write("Account Number: ");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Book Number: ");
                        var bookNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Number of Books:");
                        var quantity = Convert.ToInt32(Console.ReadLine());
                        Library.Issue(accountNumber, bookNumber, quantity);
                        Console.WriteLine("Book issued successfully !");
                        break;
                  
                    case "3":
                        Console.Write("Account Number: ");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Book Number: ");
                        bookNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Number of Books:");
                        quantity = Convert.ToInt32(Console.ReadLine());
                        Library.Deposit(accountNumber, bookNumber, quantity);
                        Console.WriteLine("Book deposited successfully !");
                        break;

                    case "4":
                        break;

                    case "5":
                        Console.WriteLine("Account Number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        var transactions = Library.GetAllTransactions(accountNumber);
                        foreach(var tran in transactions)
                        {
                            Console.WriteLine($"Id : {tran.TransactionId}, Date: {tran.TransactionDate}, Type: {tran.TypeOfTransaction}, Account Number :{tran.AccountNumber}, Book Number: {tran.BookNumber}");
                        }

                        break;

                    case "6":
                        var books = Library.GetAllBooks();
                        foreach (var item in books)
                        {
                            Console.WriteLine($"Book Number:{item.BookNumber}, Title:{item.Title}, Quantity:{item.Quantity}, Book Added Date:{item.BookAddedOn}");
                        }
                        break;

                    case "7":
                        Console.Write("Book title: ");
                        var bookTitle = Console.ReadLine();
                        Console.Write("Number of Books: ");
                        var bookQuantity = Convert.ToInt32((Console.ReadLine()));
                        var book = Library.AddBook(bookTitle, bookQuantity);
                        Console.WriteLine($"BN: {book.BookNumber}, BT:{book.Title}, Quantity : {book.Quantity}");
                        break;
                    

                }
            }
        }

    }
}
