using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Commands.CreateAuthor
{
  public class CreateAuthorQuery
  {
    public CreateAuthorModel Model { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    public CreateAuthorQuery(IBookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public void Handle()
    {
      var author = _context.Authors.SingleOrDefault(x => x.Name == Model.Name && x.SurName == Model.SurName);
      if (author is not null)
      {
        throw new InvalidOperationException("Yazar Zaten Mevcut");
      }
      author = _mapper.Map<Author>(Model);
      
      _context.Authors.Add(author);
      _context.SaveChanges();
    }
  }

  public class CreateAuthorModel
  {
    public int BookId { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}