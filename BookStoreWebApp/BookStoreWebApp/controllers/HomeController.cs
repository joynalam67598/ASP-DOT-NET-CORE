using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;
using BookStoreWebApp.Model;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookAlertConfig _bookAlertConfiguration;

        public HomeController(IOptions<BookAlertConfig> bookAlertConfiguration)
        {
            _bookAlertConfiguration = bookAlertConfiguration.Value;
        }
        public ViewResult Index()
        {
            bool isDisplay = _bookAlertConfiguration.DisplayAlert;

            
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
