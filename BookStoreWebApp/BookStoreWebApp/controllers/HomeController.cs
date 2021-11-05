using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using BookStoreWebApp.model;
using BookStoreWebApp.Model;
using BookStoreWebApp.Repository;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BookStoreWebApp.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookAlertConfig _bookAlertConfiguration;
        private readonly IMessageRepository _messageRepository;
        private readonly IUserService _userService;

        private readonly IEmailService _emailService;

        public HomeController(IOptionsSnapshot<BookAlertConfig> bookAlertConfiguration, 
            IMessageRepository messageRepository, IUserService userService, IEmailService emailService)
        {
            _bookAlertConfiguration = bookAlertConfiguration.Value;
            _messageRepository = messageRepository;
            _userService = userService;
            _emailService = emailService;
        }
        public async Task<ViewResult> Index()
        {
            //UserEmailOptions emailOptions = new UserEmailOptions
            //{
            //    ToEmails = new List<string>() { "test@gmail.com" }, //fake smtp credentials
            //    PlaceHolders = new List<KeyValuePair<string, string>>()
            //    {
            //        new KeyValuePair<string, string>("{{UserName}}","Microsoft"),
            //    }
            //};

            // await _emailService.SendTestEmail(emailOptions);

            //var userId = _userService.GetUserID();
            //var isLoggedIn = _userService.IsAuthenticated();

            //bool isDisplay = _bookAlertConfiguration.DisplayAlert;
            //var value = _messageRepository.GetName();

            
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
