﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
       
        #region Properties
        [Key]
        public int AccountNumber { get; set; }              //user's library account number 

        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be more than 50 characters of length")]
        public string EmailAddress { get; set; }            //email address of user

        public int NumberOfIssuedBooks { get; set; }        // number of books issued by library account holder

        public DateTime CreatedDate { get; private set; }           //date of account creation

        public virtual ICollection<Transaction> Transactions{ get; set; }
        #endregion

        #region Constructor

        public Account()
        {
           CreatedDate = DateTime.UtcNow;
        }


        #endregion
        #region Methods

        // issuing book means increasing numberOfIssuedBook in account table
        public int Issue(int numberOfBooks)
        {
            NumberOfIssuedBooks += numberOfBooks;
            return numberOfBooks;
        }

        // issuing book means decreasing numberOfBook in account table
        public int Deposit(int numberOfBooks)
        {
            if (numberOfBooks > NumberOfIssuedBooks)
                throw new ArgumentOutOfRangeException("numberOfBooks","Number of books to deposit cannot exceed than number of issued books");

            NumberOfIssuedBooks = NumberOfIssuedBooks - numberOfBooks;
            return NumberOfIssuedBooks;
        }

       

        #endregion

    }
}
