using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;
using Microsoft.Extensions.Configuration;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;

        public HomeController(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public ViewResult Index()
        {
            var result = configuration["AppName"];
            var key1 = configuration["info:key1"]; // object access korar niom.
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
