using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Tahuan.BookStore.Helpers;

namespace Tahuan.BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required(ErrorMessage ="The name cannot be missing.")]
        //[MyCustomValidationAttribute("azure")]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        public string Description { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage ="Language is required")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Required]
        [Display(Name = "Total pages of book")]
        public int TotalPages { get; set; }

    }
}
