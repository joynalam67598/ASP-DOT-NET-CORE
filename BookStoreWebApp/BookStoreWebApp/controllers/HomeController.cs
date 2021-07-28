using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string ViewDataAttribute { get; set; }
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public BookModel Book { get; set; }

        public ViewResult Index()
        {
            ViewBag.Title = "Book Store Web APP";
            dynamic data = new ExpandoObject();
            data.id = 1;
            data.name = "akib";
            ViewBag.Data = data;
            ViewData["book"] = new BookModel() {Author = "New one", Id = 10};
            ViewDataAttribute = "This is updated";
            Title = "Home Page";
            return View();
        }
        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
