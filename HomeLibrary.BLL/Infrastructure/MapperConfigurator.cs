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
            config.CreateMap<Author, AuthorDto>().ReverseMap();
            config.CreateMap<Image, ImageDto>().ReverseMap();
            config.CreateMap<Tag, TagDto>().ReverseMap();
            config.CreateMap<Book, BookDto>().ReverseMap();
        }
    }
}
