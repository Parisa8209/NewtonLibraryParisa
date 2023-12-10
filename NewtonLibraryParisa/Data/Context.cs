using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.EntityFrameworkCore;
using NewtonLibraryParisa.Models;
using EntityFrameworkCore.EncryptColumn.Extension;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace NewtonLibraryParisa.Data
{
    internal class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<returnedBook> ReturnedBooks { get; set; }
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:newtonlib.database.windows.net,1433;Initial Catalog=NewtonLibraryParisaA;Persist Security Info=False;User ID=NewtonLibraryParisaA;Password=NewtonLibrary1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");




            //optionsBuilder.UseSqlServer(@"Server =localhost; Database= NewtonLibraryParisa;Trusted_Connection= True;Trust Server Certificate = Yes; User Id = NewtonLibrary; password=NewtonLibrary");
        }
        private readonly IEncryptionProvider _provider;
        public Context()
        {
            this._provider = new GenerateEncryptionProvider("a2f04b9c8e23d5f1b6dc7a9e8b40cf32");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._provider);
        }
    }
}
