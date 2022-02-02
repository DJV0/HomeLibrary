using AutoMapper;
using HomeLibrary.DAL.Entities;
using HomeLibrary.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.Infrastructure
{
    public class MapperConfigurator : Profile
    {
        public MapperConfigurator(IMapperConfigurationExpression config)
        {
            config.CreateMap<Author, AuthorDto>()
                .ForMember(authorDto => authorDto.FullName, opt => opt
                                                                .MapFrom(author => author.FirstName + " " + author.LastName));
            config.CreateMap<AuthorDto, Author>()
                .ForMember(author => author.FirstName, opt => opt
                                            .MapFrom(authorDto => authorDto.FullName.Split(' ', StringSplitOptions.None)[0]))
                .ForMember(author => author.LastName, opt => opt
                                            .MapFrom(authorDto => authorDto.FullName.Split(' ', StringSplitOptions.None)[1]));

            config.CreateMap<Image, ImageDto>().ReverseMap();
            config.CreateMap<Tag, TagDto>().ReverseMap();
            config.CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
