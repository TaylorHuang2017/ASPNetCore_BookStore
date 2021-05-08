﻿using System;
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
                new BookModel(){ Id =1, Title = "MVC", Author = "Nitish"},
                new BookModel(){ Id =2, Title = "DotNet Core", Author = "Nitish"},
                new BookModel(){ Id =3, Title = "C#", Author = "Monika"},
                new BookModel(){ Id =4, Title = "Java", Author = "Taylor"},
                new BookModel(){ Id =5, Title = "Php", Author = "Frank"},
            };
        }
    }


 
}
