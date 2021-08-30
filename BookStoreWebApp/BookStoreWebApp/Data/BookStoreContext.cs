using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebApp.Data
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> option) : base(option)
        {

        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Languages { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=.; Database=BookStore; Integrated Security= true;");
        //     base.OnConfiguring(optionsBuilder);
        // } Start up e use korle ekhane ar korte hobe na.
    }
}
