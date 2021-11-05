using BookStoreWebApp.model;
using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace BookStoreWebApp.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        public readonly IBookRepository _bookRepository = null;
        public readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IBookRepository bookRepository,
            ILanguageRepository languageRepository,
            IWebHostEnvironment webHostEnvironment )
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;

        }

        public async Task<ViewResult> GetAllBooks()
        {
            var allBooks = await _bookRepository.GetAllBooks();
            return View(allBooks);
        }
        [Route(template: "~/book-details/{id:int?}",Name = "bookDetailsRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var bookDetails = await _bookRepository.GetBookById(id);
            return View(bookDetails);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddBook(bool isSuccess = false, int bookId = 0)
        {
            ViewBag.isSuccess = isSuccess;
            ViewBag.bookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {
                    const string folder = "images/book/cover/";
                    bookModel.CoverImageUrl = await UploadImage(folder,bookModel.CoverPhoto);
                }
                if (bookModel.BookPdf != null)
                {
                    const string folder = "file/book/pdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);
                }
                if (bookModel.GalleryPhotos != null)
                {
                    const string folder = "images/book/gallery/";

                    bookModel.Gallery = new List<GalleryModel>();
                    
                    foreach (var photo in bookModel.GalleryPhotos)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = photo.Name,
                            Url = await UploadImage(folder, photo),
                        };
                        bookModel.Gallery.Add(gallery);
                    }
                }
                var bookId =  _bookRepository.AddNewBook(bookModel);
                if (bookId > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId });
                }

            }
            ModelState.AddModelError("","This is custom error message");
            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
            var serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
            
            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
