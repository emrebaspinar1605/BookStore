using WebAPI.DbOperations;
using WebAPI.Entities;

namespace TestSetup
{
  public static class Genres
  {
    public static void AddGenres(this BookStoreDbContext context)
    {
      context.Genres.AddRange(
        new Genre{Name = "Polisiye"},

        new Genre{Name = "Kurgu"},
        
        new Genre{Name = "Bilim Kurgu"},
        
        new Genre{Name = "Aksiyon"},
        
        new Genre{Name = "Roman"}
        );
      context.SaveChanges();
    }

  }

}