using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Application.GenreOperations.Commands.CreateGenre;
using WebAPI.Application.GenreOperations.Commands.DeleteGenre;
using WebAPI.Application.GenreOperations.Commands.UpdateGenre;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.DbOperations;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("[controller]s")]
  public class GenreController : Controller
  {
    private readonly BookStoreDbContext _context;
    private readonly IMapper _mapper;
    public GenreController(IMapper mapper, BookStoreDbContext context)
    {
      _mapper = mapper;
      _context = context;
    }
    [HttpGet]
    public IActionResult GetGenres()
    {
      GetGenresQuery query =new GetGenresQuery(_context,_mapper);
      var result = query.Handle();
      return Ok(result);
    }
    [HttpGet("id")]
    public IActionResult GetGenreByID(int id)
    {
      GenreViewModel result;
      GetGenreDetailQuery query = new GetGenreDetailQuery(_context,_mapper);
      GetGenreDetailQueryValidator validate = new GetGenreDetailQueryValidator();
      query.GenreId = id;
      validate.ValidateAndThrow(query);
      result = query.Handle();
      return Ok(result);
    }
    [HttpPost]
    public IActionResult AddGenre([FromBody]CreateGenreModel newGenre)
    {
      CreateGenreQuery query = new CreateGenreQuery(_context);
      query.Model = newGenre;
      CreateGenreQueryValidator validate = new CreateGenreQueryValidator();
      validate.ValidateAndThrow(query);
      query.Handle();
      return Ok();
    }
    [HttpPut("id")]
    public IActionResult UpdateGenre(int id,[FromBody] UpdateGenreModel updateGenre)
    {
      UpdateGenreQuery query = new UpdateGenreQuery(_context);
      query.GenreId = id;
      query.Model = updateGenre;
      
      UpdateGenreQueryValidator validate = new UpdateGenreQueryValidator();
      validate.ValidateAndThrow(query);

      query.Handle();
      return Ok();
    }
    [HttpDelete("id")]
    public IActionResult DeleteGenre(int id)
    {
      DeleteGenreQuery query = new DeleteGenreQuery(_context);
      query.GenreId = id;

      DeleteGenreQueryValidator validate = new DeleteGenreQueryValidator();
      validate.ValidateAndThrow(query);

      query.Handle();
      return Ok();
    }

  }
}