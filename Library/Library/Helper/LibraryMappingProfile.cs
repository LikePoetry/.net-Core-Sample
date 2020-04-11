using System;
using AutoMapper;
using Library.API.Entities;
using Library.Models;

namespace Library.Helper
{
    public class LibraryMappingProfile:Profile
    {
        public LibraryMappingProfile()
        {
            CreateMap<Author, AuthorDto>().ForMember(dest => dest.Age, config =>
               config.MapFrom(src => src.BirthData.GetHashCode()));
            CreateMap<Book, BookDto>();
            CreateMap<BookForCreationDto, Book>();
            CreateMap<AuthorForCreationDto, Author>();
        }
    }
}
