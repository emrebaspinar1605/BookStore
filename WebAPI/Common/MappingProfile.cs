using AutoMapper;
using WebAPI.Application.AuthorOperations.Commands.CreateAuthor;
using WebAPI.Application.AuthorOperations.Commands.UpdateAuthor;
using WebAPI.Application.AuthorOperations.Queries.GetAuthorById;
using WebAPI.Application.AuthorOperations.Queries.GetAuthors;
using WebAPI.Application.BookOperations.Commands.CreateBook;
using WebAPI.Application.BookOperations.Commands.GetBooks;
using WebAPI.Application.BookOperations.Commands.GetById;
using WebAPI.Application.GenreOperations.Commands.CreateGenre;
using WebAPI.Application.GenreOperations.Queries.GetGenreDetail;
using WebAPI.Application.GenreOperations.Queries.GetGenres;
using WebAPI.Entities;

namespace WebAPI.Common
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateBookModel,Book>();

      CreateMap<Book,BooksViewModel>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src => src.Genre.Name));

      CreateMap<Book,BookByIdVM>().ForMember(dest => dest.Genre , opt => opt.MapFrom(src => src.Genre.Name));


      CreateMap<Genre,GenresViewModel>();

      CreateMap<Genre,GenreViewModel>();


      CreateMap<Author,AuthorViewModel>();

      CreateMap<Author,AuthorByIdVM>().ForMember(dest => dest.Book , opt => opt.MapFrom(src => src.Book.Name));

      CreateMap<CreateAuthorModel,Author>();
    }
  }
}