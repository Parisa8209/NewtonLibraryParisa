using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonLibraryParisa.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.EncryptColumn.Attribute;

namespace NewtonLibraryParisa.Models
{
    internal class Borrower
    {
        
        public int BorrowerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? LoanCard { get; set; }
        [EncryptColumn]
        public string? LoanCardPIN { get; set; }
            
        public DateTime? LoanDate { get; set; }
        public DateTime? ValidReturnDate
        {
            get
            {
                return LoanDate?.AddDays(14);
            }
            set
            {
                LoanDate = value;
            }
        }
        public ICollection<Book> Books { get; set; } = new List<Book>();


    }
}
