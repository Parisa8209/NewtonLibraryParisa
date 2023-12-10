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
    internal class returnedBook
    {
        public int Id { get; set; }

        public static int Count;
        public string Name { get; set; } = "Returned:" + " " + ++Count;

        public string? Title { get; set; }

        public DateTime DayBookReturned { get; set; }


        public Book? Book { get; set; }
    }
}
