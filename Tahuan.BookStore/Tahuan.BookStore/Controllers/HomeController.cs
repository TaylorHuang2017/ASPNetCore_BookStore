using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Tahuan.BookStore.Models;

namespace Tahuan.BookStore.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController: Controller
    {
        [Route("~/")]
        public ViewResult Index()
        {
            //////
            ViewBag.Title = "Taylor";

            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Tairan";

            ViewBag.Data = data;

            ///////
            ViewData["book"] = new BookModel() { Author = "Lei", Id = 10};


            return View();
        }

        [Route("about-us", Name ="about-us", Order = 1)][HttpGet]
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
