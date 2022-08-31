using Microsoft.EntityFrameworkCore;
using WebAPI.Entities;

namespace WebAPI.DbOperations
{
  public class BookStoreDbContext : DbContext,IBookStoreDbContext
  {
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options ) : base(options)
    {}

    public DbSet<Genre> Genres { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

    public override int SaveChanges()
    {
      return base.SaveChanges();
    }
  }
}