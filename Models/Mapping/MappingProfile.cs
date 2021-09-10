using AutoMapper;
using DataBaseRepository.DTO_s;
using DataBaseRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManBookAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<BookDto, Book>();
            CreateMap<Man, ManDto>();
            CreateMap<ManDto, Man>();
            CreateMap<Author, AuthorDto>();
            CreateMap<AuthorDto, Author>();
            CreateMap<Genre, GenreDto>();
            CreateMap<GenreDto, Genre>();
        }
    }
}
