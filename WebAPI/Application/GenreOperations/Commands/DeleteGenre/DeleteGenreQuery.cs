using System;
using System.Linq;
using WebAPI.DbOperations;

namespace WebAPI.Application.GenreOperations.Commands.DeleteGenre
{
  public class DeleteGenreQuery
  {
    public int GenreId { get; set; }
    private readonly IBookStoreDbContext _context;
    public DeleteGenreQuery( IBookStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(g => g.Id == GenreId);
      if (genre is null)
      {
        throw new InvalidOperationException("Kitap türü Bulunamadı.");
      }
      _context.Genres.Remove(genre);
      _context.SaveChanges();
    }
  }

}