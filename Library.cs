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

        /// <summary>
        /// Issue book to account
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="bookNumber"></param>
        /// <param name="quantity"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        public static void Issue(int accountNumber, int bookNumber, int quantity)
        {
            try
            {
                // decrease number of books in library 
                Book book = GetBookByBookNumber(bookNumber);

                var newQuantity = book.Issue(quantity);
                book.Quantity = newQuantity;

                // increase number of issued books in account
                var account = GetAccountByAccountNumber(accountNumber);

                newQuantity = account.Issue(quantity);
                account.NumberOfIssuedBooks = newQuantity;

                // update transaction table in database
                var transaction = new Transaction
                {
                    TransactionDate = DateTime.UtcNow,
                    TypeOfTransaction = TransactionType.Debit,
                    AccountNumber = accountNumber,
                    BookNumber = bookNumber,
                    NumberOfBooks = quantity
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
            catch
            {
                //Log
                throw;
            }
        }

      /// <summary>
      /// Deposit book into account
      /// </summary>
      /// <param name="accountNumber"></param>
      /// <param name="bookNumber"></param>
      /// <param name="quantity"></param>
      /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static void Deposit(int accountNumber, int bookNumber, int quantity)
        {
            try
            {
                var account = GetAccountByAccountNumber(accountNumber);

                var newQuantity = account.Deposit(quantity);
                account.NumberOfIssuedBooks = newQuantity;

                Book book = GetBookByBookNumber(bookNumber);

                newQuantity = book.Deposit(quantity);
                book.Quantity = newQuantity;                        //assign updated number of books 


                var transaction = new Transaction
                {
                    TransactionDate = DateTime.UtcNow,
                    TypeOfTransaction = TransactionType.Credit,
                    NumberOfBooks = quantity,
                    AccountNumber = accountNumber,
                    BookNumber = bookNumber
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();
            }
            catch
            {
                //Log
                throw;
            }
        }

        
        public static List<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate).ToList();
        }


        private static Book GetBookByBookNumber(int bookNumber)
        {
            var book = db.Books.Where(b => b.BookNumber == bookNumber).FirstOrDefault();
            if (book == null)
                throw new ArgumentOutOfRangeException("Invalid account number");
            return book;
        }

        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                throw new ArgumentOutOfRangeException("Invalid account number");
            return account;
        }
    }
}

