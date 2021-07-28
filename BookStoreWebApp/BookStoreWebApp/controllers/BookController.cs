using BookStoreWebApp.model;
using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Controllers
{
    public class BookController : Controller
    {
        // type of the repository.
        public readonly BookRepository _bookRepository = null;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        [Route(template: "book-details/{id}",Name = "bookDetailsRoute")]
        public ViewResult GetBook(int id)
        {
            var data = _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddBook(bool isSuccess=false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookModel bookModel)
        {
            var bookId = _bookRepository.AddNewBook(bookModel);
            if (bookId > 0)
            {
                return RedirectToAction(nameof(AddBook),new{ isSuccess = true , bookId = bookId});
            }
            return View();
        }
    }
}
