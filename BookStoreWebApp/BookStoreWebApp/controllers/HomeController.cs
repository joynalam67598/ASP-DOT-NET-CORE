using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStoreApp.controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var obj = new { Id = 1, Name = "View discovery" };
            return View(obj);
            //return View("~/TempView/TempView.cshtml", obj);  // return view form other location
            // ~/ is use for root == ../../
            //return View("ContectUs",obj);  // is name of view is not equal name of action
        }
        public ViewResult AboutUs()
        {
            return View();
        }
    }
}
