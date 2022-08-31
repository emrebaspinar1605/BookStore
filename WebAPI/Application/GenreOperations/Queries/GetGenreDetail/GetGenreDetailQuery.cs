using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;

namespace WebAPI.Application.GenreOperations.Queries.GetGenreDetail
{
  public class GetGenreDetailQuery
  {
    public int GenreId { get; set; }
    public readonly IBookStoreDbContext _context;
    public readonly IMapper _mapper;
    public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public GenreViewModel Handle()
    {
      var genre = _context.Genres.SingleOrDefault(x => x.IsActive && x.Id == GenreId);
      if(genre is null)
      {
        throw new InvalidOperationException("Kitap Türü Bulunamadı");
      }
      return _mapper.Map<GenreViewModel>(genre);
    }

  }
  public class GenreViewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }
}