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
    }
}
