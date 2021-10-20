using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;
using BookStoreWebApp.Model;
using BookStoreWebApp.Repository;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BookStoreWebApp.Services;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookAlertConfig _bookAlertConfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;

        public HomeController(IOptionsSnapshot<BookAlertConfig> bookAlertConfiguration, 
            IMessageRepository messageRepository, IUserService userService)
        {
            _bookAlertConfiguration = bookAlertConfiguration.Value;
            _messageRepository = messageRepository;
            _userService = userService;
        }
        public ViewResult Index()
        {
            var userId = _userService.GetUserID();
            var isLoggedIn = _userService.IsAuthenticated();

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
