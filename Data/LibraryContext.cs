using Microsoft.EntityFrameworkCore;
using WorkingWithDatabasesDevCareer.Models;

namespace WorkingWithDatabasesDevCareer.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        public DbSet<Book> Books => Set<Book>();
      
    }
}
