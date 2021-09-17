using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreWebApp.model;

namespace BookStoreWebApp.Repository
{
    public interface IBookRepository
    {
        int AddNewBook(BookModel bookModel);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById( int id);
        Task<List<BookModel>> GetTopBookAsync(int count);
        List<BookModel> SearchBook(string title, string author);

        string GetAppName();
    }
}