using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ViewResult Index()
        {
            var result = _configuration["AppName"];
            var key1 = _configuration["info:key1"]; // object access korar niom.
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
