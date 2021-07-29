using AutoMapper;
using HomeLibrary.BLL.DTOs;
using HomeLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.Mapping
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDTO>();
            CreateMap< ImageDTO, Image>();
        }
    }
}
