using System;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.BookOperations.Queries.CreateBook;
using WebAPI.Application.BookOperations.Commands.GetBooks;
using WebAPI.Application.BookOperations.Queries.GetById;
using WebAPI.Application.BookOperations.Queries.UpdateBook;

using WebAPI.DbOperations;
using WebAPI.Application.BookOperations.Commands.GetById;
using WebAPI.Application.BookOperations.Commands.CreateBook;
using WebAPI.Application.BookOperations.Commands.UpdateBook;
using WebAPI.Application.BookOperations.Commands.DeleteBook;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]s")]
  public class BookController : Controller
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
  public BookController(BookStoreDbContext context, IMapper mapper)
  {
    _context = context;
    _mapper = mapper;
  }
  [HttpGet]
    public IActionResult GetBooks()
    {
      GetBooksQuery query = new GetBooksQuery(_context,_mapper);
      var result = query.Handle();
      return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
      BookByIdVM result;
      GetBookByIdQuery query = new GetBookByIdQuery(_context,_mapper);
      GetBookByIdQueryValidator validator = new GetBookByIdQueryValidator();
    
      query.BookId = id;
      validator.ValidateAndThrow(query);
      result = query.Handle();
      return Ok(result);
        
       
    }
    [HttpPost]
    public IActionResult AddBook([FromBody]CreateBookModel newBook)
    {
      CreateBookQuery query = new CreateBookQuery(_context,_mapper);
      query.Model= newBook;
      
      CreateBookQueryValidator valid = new CreateBookQueryValidator();
      valid.ValidateAndThrow(query);
      query.Handle();
      return Ok();
    }
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id , [FromBody] UpdateBookModels newBook)
    {
      UpdateBookQuery query = new UpdateBookQuery(_context);
      query.BookId = id;
      
      UpdateBookQueryValidator validator = new UpdateBookQueryValidator();
      query.Model = newBook;
      validator.ValidateAndThrow(query);
      query.Handle();
      return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
      DeleteBookQuery query = new DeleteBookQuery(_context);
      DeleteBookQueryValidator validator = new DeleteBookQueryValidator();
    
      query.BookId = id;
      validator.ValidateAndThrow(query);
      query.Handle();
      return Ok();
    }
  }
}
