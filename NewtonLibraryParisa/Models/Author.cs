using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewtonLibraryParisa.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;
using static System.Reflection.Metadata.BlobBuilder;

namespace NewtonLibraryParisa.Models
{
    internal class Author
    {
        
        public int AuthorId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
       
        
        
        //public Book? Book { get; set; }
      
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
