﻿using BookStoreWebApp.model;
using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Http;

namespace BookStoreWebApp.Controllers
{
    public class BookController : Controller
    {
        public readonly BookRepository _bookRepository = null;
        public readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(BookRepository bookRepository,
            LanguageRepository languageRepository,
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
                if (bookModel.CoverPhoto != null)
                {
                    var folder = "images/book/cover/";
                    bookModel.CoverImageUrl = await UploadImage(folder,bookModel.CoverPhoto);
                }
                if (bookModel.GalleryPhotos != null)
                {
                    var folder = "images/book/gallery/";

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
                    return RedirectToAction(nameof(AddBook), new { isSuccess = true, bookId = bookId });
                }

            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");
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
