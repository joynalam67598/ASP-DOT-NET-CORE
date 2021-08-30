using BookStoreWebApp.model;
using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreWebApp.Controllers
{
    public class BookController : Controller
    {
        public readonly BookRepository _bookRepository = null;
        public readonly LanguageRepository _languageRepository = null;

        public BookController(BookRepository bookRepository,LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;

        }

        public async Task<ViewResult> GetAllBooks()
        {
            var allBooks = await _bookRepository.GetAllBooks();
            return View(allBooks);
        }
        [Route(template: "book-details/{id}",Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var bookDetails = await _bookRepository.GetBookById(id);
            return View(bookDetails);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public async Task<ViewResult> AddBook(bool isSuccess=false, int bookId = 0)
        {
            ViewBag.Language = new SelectList( await _languageRepository.GetLanguages(),"Id","Name");
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                var bookId =  _bookRepository.AddNewBook(bookModel);
                if (bookId > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = bookId });
                }

            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
            ModelState.AddModelError("","This is custom error message");
            return View();
        }

    }
}
