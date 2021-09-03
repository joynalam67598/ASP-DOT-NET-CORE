using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStoreWebApp.Enum;
using BookStoreWebApp.Helpers;
using BookStoreWebApp.Model;
using Microsoft.AspNetCore.Http;

namespace BookStoreWebApp.model
{
    public class BookModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public string MyFiled { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please, enter the title of your book")]
        [StringLength(50,MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please, enter the author name of your book")]
        [StringLength(25, MinimumLength = 3)]
        public string Author { get; set; }

        [Required(ErrorMessage = "Please, enter the description of your book")]
        [StringLength(500, MinimumLength = 3)]
        public string Description { get; set; }

        public string Category { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Required(ErrorMessage = "Please, choose the language of your book")]
        public LanguageEnum LanguageEnum { get; set; }

        [Required(ErrorMessage = "Please, enter the total page number of your book")]
        [Range(10,1000)]
        [Display(Name = "Total Pages of Book")]
        public int TotalPages { get; set; }

        [Display(Name ="Choose the cover photo")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }

        [Display(Name = "Choose the gallery photos")]
        [Required]
        public IEnumerable<IFormFile> GalleryPhotos { get; set; }
        
        public List<GalleryModel> Gallery { get; set; }
        [Display(Name = "Upload your book in pdf format")]
        [Required]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

    }
}
