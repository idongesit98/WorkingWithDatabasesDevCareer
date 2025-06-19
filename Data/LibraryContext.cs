using System;
using Book_Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Book_Api.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Book> Books => Set<Book>();
    public DbSet<User> Users => Set<User>();
}
