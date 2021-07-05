using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStoreApp.controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "First Home Controller";
        }
    }
}
