using System;
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
        public int AccountNumber { get; private set; }              //user's library account number 

        [Required]
        [StringLength(50, ErrorMessage = "Email cannot be more than 50 characters of length")]
        public string EmailAddress { get; set; }            //email address of user

        public int NumberOfIssuedBooks { get; private set; }        // number of books issued by library account holder

        public DateTime CreatedDate { get; private set; }           //date of account creation
        #endregion

        #region Constructor

        public Account()
        {
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
