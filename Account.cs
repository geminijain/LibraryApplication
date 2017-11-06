using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    /// <summary>
    /// class implementation of account
    /// </summary>
    public class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        public int AccountNumber { get; }              //user's library account number 

        public string EmailAddress { get; set; }            //email address of user

        public int NumberOfIssuedBooks { get; private set; }        // number of books issued by library account holder

        public DateTime CreatedDate { get; private set; }           //date of account creation
        #endregion

        #region Constructor

        public Account()
        {
             AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.UtcNow;
        }


        #endregion
        #region Methods

        public int Issue(int numberOfBooks)
        {
            NumberOfIssuedBooks += numberOfBooks;
            return NumberOfIssuedBooks;
        }

        public void Deposit(int numberOfBooks)
        {
            NumberOfIssuedBooks -= numberOfBooks;

        }

       

        #endregion

    }
}
