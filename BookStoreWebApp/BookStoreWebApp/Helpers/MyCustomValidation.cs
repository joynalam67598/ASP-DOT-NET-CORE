using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Helpers
{
    public class MyCustomValidation : ValidationAttribute
    {
        public MyCustomValidation(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return new ValidationResult("Value is empty");
            var bookName = value.ToString();
            return bookName != null && bookName.Contains(Text) ? ValidationResult.Success : new ValidationResult(ErrorMessage ?? "Book name dose not contain desire value");
            //error message thekle ota dekhabe else amader ta dekaba.
        }


    }
}
