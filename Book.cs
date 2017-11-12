using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    /// <summary>
    /// class implementation of book
    /// </summary>

    public class Book
    {
        #region Properties
        [Key]
        public int BookNumber { get; set; }          // book id 

        [Required]
        [StringLength(50,ErrorMessage ="Title cannot be more than 50 characters of length")]
        public string Title { get; set; }        // book title
        public int Quantity { get; set; }        // total number of books 
        public DateTime BookAddedOn { get; set; }
        public virtual ICollection<Transaction> Transactions{ get; set; }


        #endregion

        #region Constructor
        public Book()
        {
            BookAddedOn = DateTime.UtcNow;              

        }
        #endregion

        #region Method
        
        // issuing book means decreasing number of book in book table
        public int Issue(int numberOfBooks)
        {
            if (numberOfBooks > Quantity)
               throw new ArgumentOutOfRangeException("numberOfBooks", "Insufficient books");
            Quantity =  Quantity - numberOfBooks;
            return Quantity;
        }

        //deposit book means increasing number of books in book table
        public int Deposit(int numberOfBooks)
        {
            Quantity = Quantity + numberOfBooks;
            return Quantity;
        }
        #endregion

    }
}
