using HomeLibrary.BLL.Interfaces;
using HomeLibrary.DAL;
using HomeLibrary.DAL.Entities;

namespace HomeLibrary.BLL.Services
{
    public class BookService : GenericService<Book>, IBookService
    {
        public BookService(HomeLibraryDbContext context) : base(context) { }
    }
}
