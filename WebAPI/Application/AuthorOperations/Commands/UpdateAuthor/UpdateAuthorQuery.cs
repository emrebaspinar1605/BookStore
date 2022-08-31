using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Common;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
  public class UpdateAuthorQuery
  {
    public int AuthorId { get; set;}
    public UpdateAuthorModel Model{ get; set; }
    private readonly IBookStoreDbContext _context;


    public UpdateAuthorQuery(IBookStoreDbContext context)
    {
      _context = context;
    }
    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
      if (author is null)
      {
        throw new InvalidOperationException("Yazar Bulunamadı.");
      }
      author.BookId = Model.BookId != default ? Model.BookId :author.BookId;
      author.Name = Model.Name != default ? Model.Name : author.Name;
      author.SurName = Model.SurName != default ? Model.SurName : author.SurName;

      _context.SaveChanges();
    }
  }

  public class UpdateAuthorModel
  {

    public int BookId { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
  }
}