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
                .Include(book => book.Images.Take(1))
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
    }
}
