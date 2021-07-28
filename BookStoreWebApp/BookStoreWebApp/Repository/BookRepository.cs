using BookStoreWebApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext  _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public int AddNewBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                TotalPages = bookModel.TotalPages,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,


            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                        {
                            Id = book.Id,
                            Title = book.Title,
                            Description = book.Description,
                            Author = book.Author,
                            Category = book.Category,
                            Language = book.Language,
                            TotalPages = book.TotalPages,

                        }
                    );
                }
            }

            return books;
        }
        public async Task<BookModel> GetBookById( int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var bookDetails = new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Category = book.Category,
                    Language = book.Language,
                    TotalPages = book.TotalPages,
                };
                return bookDetails;
            }

            return null;
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title == title || x.Author == author).ToList();
        }
        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =  1 , Title = "Dot" , Author = "I"},
                new BookModel(){Id =  2 , Title = "Net" , Author = "He"},
                new BookModel(){Id =  3 , Title = "Core" , Author = "They"},

            };
        }

    }
}
