using NewtonLibraryParisa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;
using System.Net;

namespace NewtonLibraryParisa.Data
{
    internal class DataAccess
    {
        private readonly Context _context;

        public DateTime DayBookReturned { get; private set; }

        public DataAccess(Context context)
        {
            _context = context;
        }
        public void Seed()
        {
            using (Context context = new Context())
            {

                Author author1 = new Author();
                //author1.AuthorID = 1;
                author1.FirstName = "Anna";
                author1.LastName = "Janson";
                //author1.BookID = 1;

                Author author2 = new Author();
                //author2.AuthorID = 2;
                author2.FirstName = "John ";
                author2.LastName = "Oliver";
                //author2.BookID = 2;

                Author author3 = new Author();
                //author3.AuthorID = 3;
                author3.FirstName = "Marry";
                author3.LastName = "Nilson";
                // author3.BookID = 3;

                Author author4 = new Author();
                //author3.AuthorID = 3;
                author4.FirstName = "Harry";
                author4.LastName = "Erikson";


                Book book1 = new Book();
                //book1.BookID = 1;
                book1.Title = "Test";
                book1.ISBN = "1234BA3456";
                book1.PublishedYear = 1990;
                book1.Grade = 1.34;
                
               

                Book book2 = new Book();
                //book2.BookID = 2;
                book2.Title = "Heaven";
                book2.ISBN = "962434BA5683";
                book2.PublishedYear = 2000;
                book2.Grade = 3.2;
                

                Book book3 = new Book();
                //book3.BookID = 3;
                book3.Title = "Flowers";
                book3.ISBN = "78934434CG4569";
                book3.PublishedYear = 2010;
                book3.Grade = 4.2;

                Book book4 = new Book();
                //book3.BookID = 3;
                book4.Title = "The Best";
                book4.ISBN = "78934BY2365";
                book4.PublishedYear = 2012;
                book4.Grade = 2.4;

                Borrower borrower1 = new Borrower();
                //borrower1.BorrowerID = 1;
                borrower1.FirstName = "Parisa";
                borrower1.LastName = "Azizi";
                borrower1.LoanCard = "123E";
                borrower1.LoanCardPIN = "123456";
                DateTime? loanDate1 = DateTime.Now; 
                borrower1.LoanDate = loanDate1;

                //borrower1.BookID = 2;

                Borrower borrower2 = new Borrower();
                //borrower2.BorrowerID = 2;
                borrower2.FirstName = "Sam";
                borrower2.LastName = "Alison";
                borrower2.LoanCard = "456B";
                borrower2.LoanCardPIN = "987654";
                DateTime? loanDate2 = DateTime.Now; 
                borrower2.LoanDate = loanDate2;

                //borrower2.BookID = 1;

                Borrower borrower3 = new Borrower();
                //borrower3.BorrowerID = 3;
                borrower3.FirstName = "Mona";
                borrower3.LastName = "Adib";
                borrower3.LoanCard = "678T";
                borrower3.LoanCardPIN = "456789";
                DateTime? loanDate3 = DateTime.Now; 
                borrower3.LoanDate = loanDate3;


                book1.Authors.Add(author1);
                book1.Authors.Add(author3);
                book2.Authors.Add(author2);
                book3.Authors.Add(author3);
                book4.Authors.Add(author4);

                author1.Books.Add(book1);
                author3.Books.Add(book1);
                author2.Books.Add(book2);
                author3.Books.Add(book3);
                author4.Books.Add(book4);

                borrower1.Books.Add(book1);
                borrower2.Books.Add(book2);
                borrower3.Books.Add(book3);
                borrower3.Books.Add(book4);


                context.Authors.AddRange(author1, author2, author3, author4);
                context.Books.AddRange(book1, book2, book3, book4);
                context.Borrowers.AddRange(borrower1, borrower2, borrower3);

                context.SaveChanges();

                author1.Books = new List<Book>() { book1, book3 };
                author2.Books = new List<Book>() { book2 };
                author3.Books = new List<Book>() { book3 };
                author4.Books = new List<Book>() { book4 };


                book1.Authors = new List<Author>() { author1, author3 };
                book2.Authors = new List<Author>() { author2 };
                book3.Authors = new List<Author>() { author3 };
                book4.Authors = new List<Author>() { author4 };

                borrower1.Books = new List<Book>() { book1 };
                borrower2.Books = new List<Book>() { book2 };
                borrower3.Books = new List<Book>() { book3 };
                borrower3.Books = new List<Book>() { book4 };



                int bookIdToFetch = 1; 
                var book = context.Books    
                .Include(b => b.Authors)
                .FirstOrDefault(b => b.BookId == bookIdToFetch);

                if (book != null)
                {
                    Console.WriteLine($"Book Title: {book.Title}");

                    if (book.Authors.Any())
                    {
                        Console.WriteLine("Authors: ");
                        foreach (var author in book.Authors)
                        {
                            Console.WriteLine($"{author.FirstName} {author.LastName}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No authors found for this book.");
                    }
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }
        }
        public void RunMenu()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Library Management Menu:");
                Console.WriteLine("1. Add Author");
                Console.WriteLine("2. Add Book");
                Console.WriteLine("3. Add Borrower");
                Console.WriteLine("4. Borrow a Book");
                Console.WriteLine("5. Return a Book");
                Console.WriteLine("6. Show Borrower Loan History");
                Console.WriteLine("7. Show Book Loan History");
                Console.WriteLine("8. Remove All Data (Authors, Books, Borrowers)");
                Console.WriteLine("9. Exit");

                Console.Write("Enter your choice (1-9): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAuthor();
                        break;

                    case "2":
                        AddBook();
                        break;

                    case "3":
                        AddBorrower();
                        break;

                    case "4":
                        Console.Write("Enter Book ID to borrow: ");
                        if (int.TryParse(Console.ReadLine(), out int bookIdToBorrow))
                        {
                            Console.Write("Enter Borrower ID: ");
                            if (int.TryParse(Console.ReadLine(), out int borrowerIdToBorrow))
                            {
                                BorrowBook(bookIdToBorrow, borrowerIdToBorrow);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Borrower ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Book ID.");
                        }
                        break;

                    case "5":
                        Console.Write("Enter Book ID to return: ");
                        if (int.TryParse(Console.ReadLine(), out int bookIdToReturn))
                        {
                            Console.Write("Enter Borrower ID: ");
                            if (int.TryParse(Console.ReadLine(), out int borrowerIdToReturn))
                            {
                                ReturnBook(bookIdToReturn, borrowerIdToReturn);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Borrower ID.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid Book ID.");
                        }
                        break;

                    case "6":
                        Console.Write("Enter Borrower LoanCardPIN: ");
                        string loanCardPIN = Console.ReadLine();
                        ShowBorrowerLoanHistory(loanCardPIN);
                        break;

                    case "7":
                        Console.Write("Enter Book ISBN: ");
                        string bookISBN = Console.ReadLine();
                        ShowBookLoanHistory(bookISBN);
                        break;

                    case "8":
                        
                        RemoveAllEntities();
                        break;

                    case "9":
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 9.");
                        break;
                }

                Console.WriteLine();
            }
        }


        public void AddAuthor()
        {
            
            var author = new Author
            {
                FirstName = "Philippa",
                LastName = " Perry"
                
            };

            
            _context.Authors.Add(author);
            _context.SaveChanges();

            Console.WriteLine("Author added successfully.");
        }

        public void AddBook()
        {
            
            var book = new Book
            {
                Title = "The Book You Wish Your Parents Had Read",
                ISBN = "1234567890",
                PublishedYear = 2020,
                Grade = 4.5
                
            };

            
            _context.Books.Add(book);
            _context.SaveChanges();

            Console.WriteLine("Book added successfully.");
        }

        public void AddBorrower()
        {
            
            var borrower = new Borrower
            {
                FirstName = "Alina",
                LastName = "Paun",
                LoanCard = "ABC123",
                LoanCardPIN = "987654",
                LoanDate = DateTime.Now

                
            };

          
            _context.Borrowers.Add(borrower);
            _context.SaveChanges();

            Console.WriteLine("Borrower added successfully.");
        }

        public void BorrowBook(int bookId, int borrowerId)
        {
            var book = _context.Books.Find(bookId);
            var borrower = _context.Borrowers.Find(borrowerId);

            if (book != null && borrower != null && book.IsAvailable)
            {
               
                book.Borrower = borrower;
                book.IsAvailable = false;

                borrower.Books.Add(book);

                _context.SaveChanges();
                Console.WriteLine("Book is borrowed successfully.");
            }
            else
            {
                Console.WriteLine("Book not found, borrower not found, or no available copies");
            }
        }

        public void ReturnBook(int bookId, int borrowerId)
        {
            var book = _context.Books.SingleOrDefault(b => b.BookId == bookId);
            var borrower = _context.Borrowers.SingleOrDefault(b => b.BorrowerId == borrowerId);

            if (book != null && borrower != null)
            {
                // Create a ReturnedBook entity
                var returnedBook = new returnedBook
                {
                    Title = book.Title,
                    DayBookReturned = DateTime.Now,
                    Book = book
                };

                // Add the returned book to the context
                _context.ReturnedBooks.Add(returnedBook);

                // Update book information
                book.IsAvailable = true;
                borrower.Books.Remove(book);

                Console.WriteLine($"Book with Id {bookId} has been returned by borrower with Id {borrowerId}.");

                // Save changes to the database
                _context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Book or borrower not found.");
            }
        }
        public void ShowBorrowerLoanHistory(string loanCardPIN)
        {
          var borrower = _context.Borrowers.Include(b => b.Books).ThenInclude(b => b.Authors).FirstOrDefault(b => b.LoanCardPIN == loanCardPIN);

          if (borrower != null)
          {
                Console.WriteLine($"Loan History for {borrower.FirstName} {borrower.LastName}:");

                foreach (var book in borrower.Books)
                {
                    Console.WriteLine($"Book Title: {book.Title}, ISBN: {book.ISBN}");
                    Console.WriteLine("Authors:");

                    foreach (var author in book.Authors)
                    {
                        Console.WriteLine($"{author.FirstName} {author.LastName}");
                    }

                    Console.WriteLine();
                }
          }
          else
          {
                Console.WriteLine("Borrower not found.");
          }
        }

        public void ShowBookLoanHistory(string ISBN)
        {
            var book = _context.Books
                .Include(b => b.Authors)
                .ThenInclude(a => a.Books)
                .FirstOrDefault(b => b.ISBN == ISBN);

            if (book != null)
            {
                Console.WriteLine($"Loan History for Book: {book.Title}, ISBN: {book.ISBN}");
                Console.WriteLine("Authors:");

                foreach (var author in book.Authors)
                {
                    Console.WriteLine($"{author.FirstName} {author.LastName}");
                }

                Console.WriteLine("Borrowers:");

                foreach (var borrower in book.Authors
                     .SelectMany(a => a.Books)
                     .Where(b => b.Borrower != null)
                     .Select(b => b.Borrower))
                {
                    Console.WriteLine($"{borrower.FirstName} {borrower.LastName}");
                }
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }

        public void RemoveAllEntities()
        {
            RemoveAllAuthors();
            RemoveAllBooks();
            RemoveAllBorrowers();

            Console.WriteLine("All data (Authors, Books, Borrowers) removed successfully.");
        }

        private void RemoveAllAuthors()
        {
            var authors = _context.Authors.ToList();
            _context.Authors.RemoveRange(authors);
            _context.SaveChanges();
        }

        private void RemoveAllBooks()
        {
            var books = _context.Books.ToList();
            _context.Books.RemoveRange(books);
            _context.SaveChanges();
        }

        private void RemoveAllBorrowers()
        {
            var borrowers = _context.Borrowers.ToList();
            _context.Borrowers.RemoveRange(borrowers);
            _context.SaveChanges();
        }
        /*public void Recreate()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }*/
    }
}


    


