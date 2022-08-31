using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.BookOperations.Commands.GetById
{
  public class GetBookByIdQuery
  {
    public int BookId { get; set;}
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetBookByIdQuery(IBookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public BookByIdVM Handle()
    {
      var book = _context.Books.Include(g => g.Genre ).SingleOrDefault(x => x.Id == BookId && x.IsActive == true);
      if (book is null)
        throw new InvalidOperationException("Kitap Bulunamadı");
      BookByIdVM vm = _mapper.Map<BookByIdVM>(book);
      
      return vm;
    }
   
  }
  public class BookByIdVM
  {
    public string Genre { get; set; }
    public string Name { get; set; }
    public int PageCount { get; set; }
    public string PublishDate { get; set; }
  }

}