using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahuan.BookStore.Models;
using Tahuan.BookStore.Repository;

namespace Tahuan.BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;


        public BookController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            //return _bookRepository.GetAllBooks();
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookById(id);
            return View(data);
        }

        public List<BookModel> SearchBooks(string bookName, string authorName)
        {
            return _bookRepository.SearchBooks(bookName, authorName);
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess = false, int bookId = 0)
        {
            var model = new BookModel()
            {
                //Language = "2"
            };

            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            //ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");

            //ViewBag.Language = GetLanguage().Select(x => new SelectListItem()
            //{
            //    Text = x.Text,
            //    Value = x.Id.ToString()
            //}).ToList();

            //var group1 = new SelectListGroup() { Name = "Group 1"} ;
            //var group2 = new SelectListGroup() { Name = "Group 2" };
            //var group3 = new SelectListGroup() { Name = "Group 3" };


            //ViewBag.Language = new List<SelectListItem>()
            //{
            //    new SelectListItem(){ Text = "Chinese", Value = "1", Group = group1},
            //    new SelectListItem(){ Text = "English", Value = "2", Group = group1},
            //    new SelectListItem(){ Text = "Spanish", Value = "3", Group = group2},
            //    new SelectListItem(){ Text = "Hindi", Value = "4", Group = group2},
            //    new SelectListItem(){ Text = "German", Value = "5", Group = group3},
            //    new SelectListItem(){ Text = "French", Value = "6", Group = group3},
            //};

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");

            //ViewBag.Language = new SelectList(, "Id", "Text");
            //ViewBag.Language = new List<string>() { "Chinese", "English", "Spanish" };
            //ModelState.AddModelError
            return View();
        }


        //private List<LanguageModel> GetLanguage()
        //{
        //    return new List<LanguageModel>()
        //    { 
        //        new LanguageModel() { Id = 1, Text = "Chinese" },
        //        new LanguageModel() { Id = 2, Text = "English" },
        //        new LanguageModel() { Id = 3, Text = "Spanish" },
        //    };
        //}
    }
}
