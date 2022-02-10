using AutoMapper;
using HomeLibrary.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibrary.Client.Infrastructure
{
    public class MapperConfigurator : Profile
    {
        public MapperConfigurator(IMapperConfigurationExpression config)
        {
            config.CreateMap<OpenLibraryBookDto.Author, AuthorDto>()
                .ForMember(authorDto => authorDto.FullName, opt => opt.MapFrom(apiAuthor => apiAuthor.name));
            config.CreateMap<OpenLibraryBookDto.Cover, ImageDto>()
                .ForMember(imageDto => imageDto.Uri, opt => opt.MapFrom(cover => cover.large));
            config.CreateMap<OpenLibraryBookDto, BookDto>()
                .ForMember(bookDto => bookDto.ISBN, opt => opt.MapFrom(apiBook => apiBook.Book.identifiers.isbn_13.FirstOrDefault()))
                .ForMember(bookDto => bookDto.Title, opt => opt.MapFrom(apiBook => apiBook.Book.title))
                .ForMember(bookDto => bookDto.PublishDate, opt => opt
                    .MapFrom(apiBook => DateTime.Parse(apiBook.Book.publish_date).Year))
                .ForMember(boookDto => boookDto.NumberOfPages, opt => opt.MapFrom(apiBook => apiBook.Book.number_of_pages))
                .ForMember(bookDto => bookDto.Authors, opt => opt.MapFrom(apiBook => apiBook.Book.authors));
        }
    }
}
