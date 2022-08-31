using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAPI.Entities;

namespace WebAPI.DbOperations
{
  public class DataGenerator
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
      {
        if (context.Books.Any())
        {
          return;
        }
        context.Genres.AddRange(
          new Genre
          {
            Name = "Polisiye"

          },
          new Genre
          {
            Name = "Kurgu"

          },
          new Genre
          {
            Name = "Bilim Kurgu"

          },
          new Genre
          {
            Name = "Aksiyon"

          },
          new Genre
          {
            Name = "Roman"

          }
        );
        context.Authors.AddRange(
          new Author{
            Name = "Arthur Conan",
            SurName ="Doyle",
            BirthDate = new DateTime(1859,05,22),
            BookId = 1
          },
          new Author{
            Name = "Halide Edib",
            SurName = "Adıvar",
            BirthDate = new DateTime(1884,06,11),
            BookId = 2
          },
          new Author{
            Name = "Cengiz",
            SurName = "Aytmatov",
            BirthDate = new DateTime(1928,12,12),
            BookId = 3
          }
        );
        context.Books.AddRange(
          new Book
            {
               // Id = 1,
                Name = "Sherlock Holmes",
                GenreId = 1, //polisiye
                PageCount = 382,
                PublishDate = new DateTime(1892,10,14)
            },
            new Book
            {
                // Id = 2,
                Name = "Ateşten Gömlek",
                GenreId = 2, 
                PageCount = 224,
                PublishDate = new DateTime(1922,06,07)
            },
            new Book
            {
                // Id = 3,
                Name = "Beyaz Gemi",
                GenreId = 2, 
                PageCount = 168,
                PublishDate = new DateTime(1970,01,15)
            }
        );
        context.SaveChanges();
      }
    }
  }
}