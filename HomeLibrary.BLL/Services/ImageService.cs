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

        public async Task<ImageDTO> AddAsync(ImageDTO entity)
        {
            var image = _mapper.Map<Image>(entity);
            if (await ExistImage(image.Id)) throw new ArgumentException("Invalid indut data!");
            await _context.Images.AddAsync(image);
            await _context.SaveChangesAsync();
            return _mapper.Map<ImageDTO>(image);
        }

        public async Task DeleteAsync(int id)
        {
            var image = await _context.Images.FindAsync(id);
            if(image == null) throw new ArgumentException("Invalid indut data!");
            _context.Images.Remove(image);
            await _context.SaveChangesAsync();

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

        public async Task UpdateAsync(ImageDTO entity)
        {
            var image = await _context.Images.FindAsync(entity.Id);
            if (image == null) throw new ArgumentException("Invalid input data!");
            _context.Entry(image).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }
        private async Task<bool> ExistImage(int id)
        {
            return await _context.Images.FindAsync(id) != null;
        }
    }
}
