using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    private static int lastBookId = 101;

    public static class Book
    {
        #region Properties
        public int BookId { get; set; }          // book id 

        public string Title { get; set; }        // book title

        public int Quantity { get; set; }        // total number of books 

        public string Author { get; set; } 

        public int PublishedYear { get; set;}

        #endregion

        #region Constructor
         
        public Book()
        {

        }


        #endregion


    }
}
