using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Data
{
    public class BookOnLoan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string LoanedTo { get; set; }
        public DateTime DateLoaned { get; set; }

    }
}
