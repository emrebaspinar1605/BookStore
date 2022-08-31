using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthorById
{
  public class GetAuthorDetailsQuery
  {
    public AuthorByIdVM Model;
    public int AuthorId { get; set; }
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetAuthorDetailsQuery(IBookStoreDbContext context,IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public AuthorByIdVM Handle()
    {
      var author = _context.Authors.Include(x => x.Book).SingleOrDefault(x => x.Id == AuthorId);
      if (author is null)
      {
        throw  new InvalidOperationException("Yazar bulunamadı");
      }
      var vm = _mapper.Map<AuthorByIdVM>(author);

      return vm;
    }
  }

  public class AuthorByIdVM
  {
    public string Name { get; set; }
    public string SurName { get; set; }
    public string BirthDate { get; set; }
    public string Book { get; set; }
  }
}