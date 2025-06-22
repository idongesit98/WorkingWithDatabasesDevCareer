using System;
using Microsoft.EntityFrameworkCore;
using WorkingWithDatabasesDevCareer.Model;

namespace WorkingWithDatabasesDevCareer.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();
}
