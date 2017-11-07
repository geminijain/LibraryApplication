using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public enum TransactionType
    {
        Issue,
        Return
    }
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public TransactionType TypeOfTransaction { get; set; }

        public int NumberOfBooks { get; set; }

        [ForeignKey("Account")]
        public int AccountNumber { get; set; }

        [ForeignKey("Book")]
        public int BookNumber { get; set; }

        public virtual Account Account { get; set; }

        public virtual Book Book { get; set; }
    }
}
