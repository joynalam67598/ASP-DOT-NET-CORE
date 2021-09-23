using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BookStoreWebApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreWebApp.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
        public readonly IBookRepository _bookRepository;
        public TopBooksViewComponent(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var books = await _bookRepository.GetTopBookAsync(count);
            return View(books);
        }
    }
}
