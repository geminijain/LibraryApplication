using System;
using System.Collections.Generic;
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
        private static int lastBookNumber = 101;

        #region Properties
        public int BookNumber { get; }          // book id 
        public string Title { get; set; }        // book title
        public int Quantity { get; set; }        // total number of books 

        #endregion

        #region Constructor
        public Book()
        {
            BookNumber = ++lastBookNumber;
        }
        #endregion

        #region Method
        //    public void AddBook(int numberOfBooks)
        //{

        //}

#endregion

    }
}
