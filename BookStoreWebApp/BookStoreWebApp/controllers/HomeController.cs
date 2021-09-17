using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;

namespace BookStoreWebApp.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [Route("~/")]
        public ViewResult Index()
        {
            return View();
        }

        // [Route("about-us")]
        // [Route("about-us")][HttpGet]
        // [HttpGet("about-us")]
        // [HttpGet("about-us",Name="about",Order=1)]

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
