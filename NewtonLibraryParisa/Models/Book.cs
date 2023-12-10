using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonLibraryParisa.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace NewtonLibraryParisa.Models
{
    internal class Book
    {

        
        public int BookId { get; set; }

        public string? Title { get; set; }
        public string? ISBN { get; set; }
        public int? PublishedYear { get; set; }
       
        public double? Grade {  get; set; }
      
       
        public Borrower? Borrower { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        //public ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>()¨;
        public ICollection<returnedBook> ReturnedBooks { get; set; }


        public bool IsAvailable { get; set; } = true;

        public Book()
        {

        }
    }
}
