using System.Linq;
using System;
using WebAPI.DbOperations;
using WebAPI.Entities;
using AutoMapper;

namespace WebAPI.Application.GenreOperations.Commands.CreateGenre
{
  public class CreateGenreQuery
  {
    public CreateGenreModel Model { get; set; }
    private readonly IBookStoreDbContext _context ;
  
    public CreateGenreQuery(IBookStoreDbContext context )
    {
      _context = context;
    }
    public void Handle()
    {
      var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
      if (genre is not null)
      {
        throw new InvalidOperationException("Kitap Türü Mevcut");
      }
      genre = new Genre();
      genre.Name = Model.Name;
      _context.Genres.Add(genre);
      _context.SaveChanges();
      
    }
  }

  public class CreateGenreModel
  {
    public string Name { get; set; }
  }
}