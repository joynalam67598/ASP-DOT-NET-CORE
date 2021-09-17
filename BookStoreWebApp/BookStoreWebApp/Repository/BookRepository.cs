using BookStoreWebApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Data;
using BookStoreWebApp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApp.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext  _context = null;
        private readonly IConfiguration  _configuration;

        public BookRepository(BookStoreContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public int AddNewBook(BookModel bookModel)
        {
            var newBook = new Books()
            {
                Title = bookModel.Title,
                Author = bookModel.Author,
                Description = bookModel.Description,
                LanguageId = bookModel.LanguageId,
                TotalPages = bookModel.TotalPages,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                CoverImage = bookModel.CoverImageUrl,
                BookPdfUrl = bookModel.BookPdfUrl,


            };
            newBook.BookGalleries = new List<BookGallery>();
            foreach (var gallery in bookModel.Gallery)
            {
                newBook.BookGalleries.Add(new BookGallery()
                {
                    Name = gallery.Name,
                    Url = gallery.Url,
                });

            }
            _context.Books.Add(newBook);
            _context.SaveChanges();
            return newBook.Id;

        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImage,

                }).ToListAsync();
            
        }
        public async Task<BookModel> GetBookById( int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImage,
                    Gallery = book.BookGalleries.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        Url = g.Url,
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl,

                }).FirstOrDefaultAsync();
        }

        public async Task<List<BookModel>> GetTopBookAsync(int count)
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Id = book.Id,
                    Title = book.Title,
                    Description = book.Description,
                    Author = book.Author,
                    Category = book.Category,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImage,

                }).Take(count).ToListAsync();
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return null;
        }

        public string GetAppName()
        {
            return _configuration["AppName"];
        }
        

    }
}
