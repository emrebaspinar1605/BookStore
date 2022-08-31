using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.GenreOperations.Commands.UpdateGenre
{
  public class UpdateGenreQuery
  {
    public int GenreId { get; set; }
    public UpdateGenreModel Model{ get; set; }
    private readonly IBookStoreDbContext _context;
   
    public UpdateGenreQuery(IBookStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(g => g.Id == GenreId);
      if(genre is null)
        throw new InvalidOperationException("Böyle Bir Kitap Türü Yok");
      if(_context.Genres.Any(g => g.Name.ToLower() == Model.Name.ToLower() && g.Id != GenreId))
        throw new InvalidOperationException("Aynı İsimli Bir Kitap Türü Mevcuttur");
      genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
      genre.IsActive = Model.IsActive;
      _context.SaveChanges();
    }
  }
  public class UpdateGenreModel
  {
    public string Name { get; set; }
    public bool IsActive { get; set; }
  }
}