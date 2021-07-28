using BookStoreWebApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Data;

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
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById( int id)
        {
            return DataSource().FirstOrDefault(x => x.Id == id);
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
