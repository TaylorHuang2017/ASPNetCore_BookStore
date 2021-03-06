using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahuan.BookStore.Data;
using Tahuan.BookStore.Models;

namespace Tahuan.BookStore.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                TotalPages = model.TotalPages,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookPdfUrl
            };

            newBook.bookGallery = new List<BookGallery>();

            foreach (var file in model.Gallery)
            {
                newBook.bookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL
                });
            }

            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;

        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                }).ToListAsync();


        }

        public async Task<List<BookModel>> GetTopBooksAsync(int count)
        {
            return await _context.Books
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl
                }).Take(count).ToListAsync();


        }



        public async Task<BookModel> GetBookById(int id)
        {
            var book = await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    Title = book.Title,
                    TotalPages = book.TotalPages,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL
                    }).ToList(),
                    BookPdfUrl = book.BookPdfUrl
                }).FirstOrDefaultAsync();
            //var book = await _context.Books.FindAsync(id);
            //return _context.Books.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (book != null)
            {
                return book;
            }

            return null;
        }

        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return null; //DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(authorName)).ToList()
        }


        //private List<BookModel> DataSource()
        //{
        //    return new List<BookModel>()
        //    {
        //        new BookModel(){ Id =1, Title = "MVC", Author = "Nitish", Description = "Model View Controller", Category="Programming", Language="English", TotalPages=568},
        //        new BookModel(){ Id =2, Title = "DotNet Core", Author = "Nitish", Description = ".NET core 3.1", Category="Programming", Language="German", TotalPages=1200},
        //        new BookModel(){ Id =3, Title = "C#", Author = "Monika", Description = "C sharp language", Category="Programming", Language="English", TotalPages=908},
        //        new BookModel(){ Id =4, Title = "Java", Author = "Taylor", Description = "Java web programming", Category="Programming", Language="Chinese", TotalPages=210},
        //        new BookModel(){ Id =5, Title = "Php", Author = "Frank", Description = "Php is here", Category="Programming", Language="English", TotalPages=340},
        //        new BookModel(){ Id =6, Title = "Azure DevOps", Author = "Frank", Description = "DevOps is the future", Category="DevOps", Language="Spanish", TotalPages=689},
        //    };
        //}
    }



}
