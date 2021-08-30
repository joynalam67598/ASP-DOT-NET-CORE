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
            // var model = new BookModel()
            // {
            //     LanguageId = "English",
            // };
            // ViewBag.LanguageId = new List<string>() {"Bengali", "English", "Hindi"};
            // ViewBag.LanguageId = new SelectList(new List<string>(){"Bengali", "English", "Hindi"});
            // ViewBag.LanguageId = new SelectList(GetLanguage(),"Id","Text");

            // var group1 = new SelectListGroup() { Name = "group1" };
            // var group2 = new SelectListGroup() { Name = "group2" };
            // var group3 = new SelectListGroup() { Name = "group3" };
            // ViewBag.Language = new List<SelectListItem>()
            // {
            //     new SelectListItem() {Text = "English", Value = "1", Group = group1},
            //     new SelectListItem() {Text = "Hindi", Value = "2", Group = group1},
            //     new SelectListItem() {Text = "Bengali", Value = "3", Group = group2},
            //     new SelectListItem() {Text = "Urdu", Value = "3", Group = group2},
            //     new SelectListItem() {Text = "USA", Value = "3", Group = group3},
            //     new SelectListItem() {Text = "UK", Value = "3", Group = group3},
            // };

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
            // var group1 = new SelectListGroup() {Name = "group1"};
            // var group2 = new SelectListGroup() {Name = "group2"};
            // var group3 = new SelectListGroup() {Name = "group3"};
            // ViewBag.LanguageId = new List<SelectListItem>()
            // {
            //     new SelectListItem() {Text = "English", Value = "1", Group = group1},
            //     new SelectListItem() {Text = "Hindi", Value = "2", Group = group1},
            //     new SelectListItem() {Text = "Bengali", Value = "3", Group = group2},
            //     new SelectListItem() {Text = "Urdu", Value = "3", Group = group2},
            //     new SelectListItem() {Text = "USA", Value = "3", Group = group3},
            //     new SelectListItem() {Text = "UK", Value = "3", Group = group3},
            // };
            ModelState.AddModelError("","This is custom error message");
            return View();
        }

    }
}
