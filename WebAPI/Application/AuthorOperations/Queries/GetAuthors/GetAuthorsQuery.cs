using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbOperations;
using WebAPI.Entities;

namespace WebAPI.Application.AuthorOperations.Queries.GetAuthors
{
  public class GetAuthorsQuery
  {
    private readonly IBookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GetAuthorsQuery(IBookStoreDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }
    public List<AuthorViewModel> Handle()
    {
      var authorList = _context.Authors.OrderBy(i => i.Id).ToList();
      List<AuthorViewModel> vm = _mapper.Map<List<AuthorViewModel>>(authorList);

      return vm;
    }
  }

  public class AuthorViewModel
  {

    public string Name { get; set; }
    public string SurName { get; set; }
    public DateTime BirthDate { get; set; }
  }
}