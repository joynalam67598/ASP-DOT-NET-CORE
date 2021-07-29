using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookStoreWebApp.model
{
    public class BookModel
    {
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
        public string Language { get; set; }
        [Required(ErrorMessage = "Please, enter the total page number of your book")]
        [Range(100,1000)]
        [Display(Name = "Total Pages of Book")] // change the label name
        public int TotalPages { get; set; }
      
    }
}
