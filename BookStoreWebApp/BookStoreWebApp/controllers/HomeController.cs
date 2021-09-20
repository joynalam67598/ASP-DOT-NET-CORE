using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;
using BookStoreWebApp.Model;
using BookStoreWebApp.Repository;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookAlertConfig _bookAlertConfiguration;
        private readonly IMessageRepository _messageRepository;

        public HomeController(IOptionsSnapshot<BookAlertConfig> bookAlertConfiguration, IMessageRepository messageRepository)
        {
            _bookAlertConfiguration = bookAlertConfiguration.Value;
            _messageRepository = messageRepository;
        }
        public ViewResult Index()
        {
            bool isDisplay = _bookAlertConfiguration.DisplayAlert;
            var value = _messageRepository.GetName();

            
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
