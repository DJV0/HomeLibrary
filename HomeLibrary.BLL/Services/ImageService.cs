using AutoMapper;
using HomeLibrary.BLL.DTOs;
using HomeLibrary.BLL.Interfaces;
using HomeLibrary.DAL;
using HomeLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.Services
{
    public class ImageService : IImageService
    {
        private readonly HomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public ImageService(HomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task AddAsync(ImageDTO entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ImageDTO>> GetAllAsync()
        {
            var images = await _context.Images.ToListAsync();
            return _mapper.Map<List<ImageDTO>>(images);
        }

        public async Task<ImageDTO> GetAsync(int id)
        {
            var image = await _context.Images.FirstOrDefaultAsync(image => image.Id == id);
            return _mapper.Map<ImageDTO>(image);
        }

        public Task UpdateAsync(ImageDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
