using HomeLibrary.BLL.Interfaces;
using HomeLibrary.DAL;
using HomeLibrary.DAL.Entities;

namespace HomeLibrary.BLL.Services
{
    public class AuthorService : GenericService<Author>, IAuthorService
    {
        public AuthorService(HomeLibraryDbContext context) : base(context) { }
    }
}
