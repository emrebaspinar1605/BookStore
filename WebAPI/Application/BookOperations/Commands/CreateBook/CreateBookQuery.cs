using System;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.BookOperations.Commands.CreateBook
{
  public class CreateBookQuery
  {
    public CreateBookModel Model {get; set;}
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;

    public CreateBookQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
      _context = dbContext;
      _mapper = mapper;
    }
    public void Handle()
    {
      var book = _context.Books.SingleOrDefault(x=> x.Name == Model.Name);
      if (book is not null)
        throw new InvalidOperationException("Kitap Zaten Mevcut");
      book = _mapper.Map<Book>(Model);

      _context.Books.Add(book);
      _context.SaveChanges();
    }
    
  }
  public class CreateBookModel
    {
      public string Name {get; set;}
      public int GenreID {get; set;}
      public int PageCount {get; set;}
      public DateTime PublishDate {get; set;}

    }
}