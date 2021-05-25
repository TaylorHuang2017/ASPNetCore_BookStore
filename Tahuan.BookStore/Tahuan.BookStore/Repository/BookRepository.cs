using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahuan.BookStore.Models;

namespace Tahuan.BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList();
        }


        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){ Id =1, Title = "MVC", Author = "Nitish", Description = "Model View Controller", Category="Programming", Language="English", TotalPages=568},
                new BookModel(){ Id =2, Title = "DotNet Core", Author = "Nitish", Description = ".NET core 3.1", Category="Programming", Language="German", TotalPages=1200},
                new BookModel(){ Id =3, Title = "C#", Author = "Monika", Description = "C sharp language", Category="Programming", Language="English", TotalPages=908},
                new BookModel(){ Id =4, Title = "Java", Author = "Taylor", Description = "Java web programming", Category="Programming", Language="Chinese", TotalPages=210},
                new BookModel(){ Id =5, Title = "Php", Author = "Frank", Description = "Php is here", Category="Programming", Language="English", TotalPages=340},
                new BookModel(){ Id =6, Title = "Azure DevOps", Author = "Frank", Description = "DevOps is the future", Category="DevOps", Language="Spanish", TotalPages=689},
            };
        }
    }


 
}
