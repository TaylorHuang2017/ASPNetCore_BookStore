using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tahuan.BookStore.Models;

namespace Tahuan.BookStore.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options)
        {

        }

        //DB tables 
        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }

        public DbSet<BookGallery> BookGallery {get; set;}

        public DbSet<Tahuan.BookStore.Models.SignupUserModel> SignupUserModel { get; set; }

        public DbSet<Tahuan.BookStore.Models.SignInModel> SignInModel { get; set; }


    }
}
