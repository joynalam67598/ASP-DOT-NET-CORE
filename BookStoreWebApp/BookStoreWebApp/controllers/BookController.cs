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

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
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

        public ViewResult AddBook(bool isSuccess=false, int bookId = 0)
        {
            var model = new BookModel()
            {
                Language = "English",
            };
            // ViewBag.Language = new List<string>() {"Bengali", "English", "Hindi"};
            // ViewBag.Language = new SelectList(new List<string>(){"Bengali", "English", "Hindi"});
            ViewBag.Language = new SelectList(GetLanguage(),"Id","Text");
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }
        [HttpPost]
        public IActionResult AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                var bookId = _bookRepository.AddNewBook(bookModel);
                if (bookId > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = bookId });
                }

            }

            // ViewBag.Language = new List<string>() { "Bengali", "English", "Hindi" };
            // ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            // ViewBag.Language = GetLanguage().Select(x=> new SelectListItem()
            // {
            //     Text = x.Text,
            //     Value = x.Id.ToString(),
            // }).ToList();
            // ViewBag.Language = new List<SelectListItem>()
            // {
            //     new SelectListItem() {Text = "English", Value = "1"},
            //     new SelectListItem() {Text = "Hindi", Value = "2", Disabled = true},
            //     new SelectListItem() {Text = "Bengali", Value = "3",Selected = true},
            // }; 

            var group1 = new SelectListGroup() {Name = "group1"};
            var group2 = new SelectListGroup() {Name = "group2"};
            var group3 = new SelectListGroup() {Name = "group3"};
            ViewBag.Language = new List<SelectListItem>()
            {
                new SelectListItem() {Text = "English", Value = "1", Group = group1},
                new SelectListItem() {Text = "Hindi", Value = "2", Group = group1},
                new SelectListItem() {Text = "Bengali", Value = "3", Group = group2},
                new SelectListItem() {Text = "Urdu", Value = "3", Group = group2},
                new SelectListItem() {Text = "USA", Value = "3", Group = group3},
                new SelectListItem() {Text = "UK", Value = "3", Group = group3},
            };
            ModelState.AddModelError("","This is custom error message");
            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() {Id = 1, Text = "Hindi"},
                new LanguageModel() {Id = 2, Text = "English"},
                new LanguageModel() {Id = 3, Text = "bengali"},
            };
        }
    }
}
