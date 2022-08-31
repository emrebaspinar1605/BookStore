using System;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace TestSetup
{
  public static class Books
  {
    public static void AddBooks(this BookStoreDbContext context)
    {
      context.Books.AddRange(
        new Book{Name = "Sherlock Holmes",GenreId = 1,PageCount = 382,PublishDate = new DateTime(1892,10,14)},
        
        new Book{Name = "Ateşten Gömlek",GenreId = 2,PageCount = 224,PublishDate = new DateTime(1922,06,07)},
        
        new Book {Name = "Beyaz Gemi",GenreId = 2,PageCount = 168,PublishDate = new DateTime(1970,01,15)}
      );
      context.SaveChanges();
    }
  }

}