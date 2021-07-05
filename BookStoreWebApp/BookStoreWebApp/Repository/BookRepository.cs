using BookStoreWebApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebApp.Repository
{
    public class BookRepository
    {
        // we can write all kind of logic here , works like provider
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBookById( int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SecarchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title == title && x.Author == author).ToList();
        }
        public List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id =  1 , Title = "Dot" , Author = "I"},
                new BookModel(){Id =  2 , Title = "Net" , Author = "He"},
                new BookModel(){Id =  3 , Title = "Core" , Author = "They"},

            };
        }

    }
}
