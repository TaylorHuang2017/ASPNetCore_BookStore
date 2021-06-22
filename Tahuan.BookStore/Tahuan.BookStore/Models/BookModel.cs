using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Tahuan.BookStore.Helpers;
using Microsoft.AspNetCore.Http;

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
        [Display(Name = "Total pages of the book")]
        public int TotalPages { get; set; }

        [Required]
        [Display(Name = "The cover photo of the book")]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Required]
        [Display(Name = "The gallery photos of the book")]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Required]
        [Display(Name = "Upload your book in .pdf format")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
