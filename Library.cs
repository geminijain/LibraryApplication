﻿using System;
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

        public static void Issue(int accountNumber, int bookNumber, int quantity)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                return;

            account.Issue(quantity);

            var book = db.Books.Where(b => b.BookNumber == bookNumber).FirstOrDefault();
            if (book == null)
                return;
            book.Issue(quantity);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TypeOfTransaction = TransactionType.Issue,
                AccountNumber = account.AccountNumber,
                BookNumber = book.BookNumber
            };
            db.Transactions.Add(transaction);
            db.SaveChanges();
        }


        public static void Deposit(int accountNumber, int bookNumber, int quantity)
        {
            var account = db.Accounts.Where(a => a.AccountNumber == accountNumber).FirstOrDefault();
            if (account == null)
                return;

            account.Deposit(quantity);

            var book = db.Books.Where(b => b.BookNumber == bookNumber).FirstOrDefault();
            if (book == null)
                return;
            book.Deposit(quantity);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.UtcNow,
                TypeOfTransaction = TransactionType.Return,
                NumberOfBooks = quantity,
                AccountNumber = account.AccountNumber,
                BookNumber = book.BookNumber
                };
                db.Transactions.Add(transaction);
                db.SaveChanges();
            
        }

        public static List<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate).ToList();
        }
    }
}

