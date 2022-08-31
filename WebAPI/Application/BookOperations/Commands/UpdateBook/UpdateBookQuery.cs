using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.BookOperations.Commands.UpdateBook
{
  public class UpdateBookQuery
  {
    public int BookId { get; set;}
    public UpdateBookModels Model{ get; set; }
    private readonly IBookStoreDbContext _context;

    public UpdateBookQuery(IBookStoreDbContext context)
    {
      _context = context;
      
    }

    public void Handle()
    {
      var book = _context.Books.SingleOrDefault(x=> x.Id == BookId);
      if (book is null)
      {
        throw new InvalidOperationException("Böyle bir kitap bulunamadı");
      }
      book.Name = Model.Name != default ? Model.Name : book.Name;
      book.GenreId = Model.GenreId != default ? Model.GenreId : book.GenreId;
      _context.SaveChanges();
    }
  }
  public class UpdateBookModels
  {
    public string Name { get; set; }
    public int GenreId { get; set; }
  }
}