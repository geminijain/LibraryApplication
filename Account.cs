using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    /// <summary>
    /// class implementation of lirary account
    /// </summary>
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        public int AccountNumber { get; }              //user's library account number 

        public string EmailAddress { get; set; }            //email address of user

        public int NumberOfBooksIssued { get; private set; }        // number of books issued by library account holder

        public DateTime CreatedDate { get; set; }           //date of account creation
        #endregion

        #region Constructor

        public Account()
        {
             AccountNumber = ++lastAccountNumber;

        }


        #endregion
        #region Methods

        public int Issue(int numberOfBooks)
        {
            NumberOfBooksIssued += numberOfBooks;
            return NumberOfBooksIssued;
        }

        public int Deposit(int numberOfBooks)
        {
            NumberOfBooksIssued -= numberOfBooks;
            return NumberOfBooksIssued;
        }

       

        #endregion

    }
}
