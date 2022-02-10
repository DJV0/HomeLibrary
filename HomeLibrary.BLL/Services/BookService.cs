using AutoMapper;
using HomeLibrary.BLL.Infrastructure;
using HomeLibrary.BLL.Interfaces;
using HomeLibrary.DAL;
using HomeLibrary.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.Services
{
    public class BookService : GenericService<Book>, IBookService
    {
        public BookService(HomeLibraryDbContext context) : base(context) { }

        public override async Task<ICollection<Book>> GetAllAsync()
        {
            return await dbContext.Books
                .Include(book => book.Authors)
                .Include(book => book.Images)
                .Include(book => book.Tags)
                .ToListAsync();
        }
        public override async Task<Book> GetByIdAsync(int id)
        {
            return await dbContext.Books
                .Include(book => book.Authors)
                .Include(book => book.Images)
                .Include(book => book.Tags)
                .FirstOrDefaultAsync(book => book.Id == id);
        }

        public override async Task<Book> AddAsync(Book entity)
        {
            dbContext.Books.Attach(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateAsync(Book entity)
        {
            var dbBook = await GetByIdAsync(entity.Id);
            dbBook.Authors.UpdateData(entity.Authors);
            dbBook.Images.UpdateData(entity.Images);
            dbBook.Tags.UpdateData(entity.Tags);
            dbContext.Entry(dbBook).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
