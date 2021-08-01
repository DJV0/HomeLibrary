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
    public class BookService : IBookService
    {
        private readonly HomeLibraryDbContext _context;
        private readonly IMapper _mapper;
        public BookService(HomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookDTO> AddAsync(BookDTO entity)
        {
            var author = _mapper.Map<Book>(entity);
            if (await ExistBook(author.Id)) throw new ArgumentException("The enter book id has already existed");
            await _context.Books.AddAsync(author);
            await _context.SaveChangesAsync();
            return _mapper.Map<BookDTO>(author);
        }

        public async Task DeleteAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book == null) throw new ArgumentException("The enter book id doesn't exist.");
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BookDTO>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO> GetAsync(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(book => book.Id == id);
            return _mapper.Map<BookDTO>(book);
        }

        public async Task UpdateAsync(BookDTO entity)
        {
            var book = await _context.Books.FindAsync(entity.Id);
            if (book == null) throw new ArgumentException("The enter book doesn't exist.");
            _context.Entry(book).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
        }

        private async Task<bool> ExistBook(int id)
        {
            return await _context.Books.FindAsync(id) != null;
        }
    }
}
