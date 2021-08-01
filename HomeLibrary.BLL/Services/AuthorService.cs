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
    public class AuthorService : IAuthorService
    {
        private readonly HomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(HomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> AddAsync(AuthorDTO entity)
        {
            var author = _mapper.Map<Author>(entity);
            if (await ExistAuthor(author.Id)) throw new ArgumentException("Invalid input data.");
            await _context.Authors.AddAsync(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task DeleteAsync(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if(author == null) throw new ArgumentException("Invalid input data.");
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AuthorDTO>> GetAllAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            return _mapper.Map<List<AuthorDTO>>(authors);
        }

        public async Task<AuthorDTO> GetAsync(int id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(author => author.Id == id);
            return _mapper.Map<AuthorDTO>(author);
        }

        public async Task UpdateAsync(AuthorDTO entity)
        {
            var author = await _context.Authors.FindAsync(entity.Id);
            if(author == null) throw new ArgumentException("Invalid input data.");
            _context.Entry(author).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> ExistAuthor(int id)
        {
            return await _context.Authors.FindAsync(id) != null;
        }
    }
}
