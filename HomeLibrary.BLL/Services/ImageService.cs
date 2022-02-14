using HomeLibrary.BLL.Interfaces;
using HomeLibrary.DAL;
using HomeLibrary.DAL.Entities;

namespace HomeLibrary.BLL.Services
{
    public class ImageService : GenericService<Image>, IImageService
    {
        public ImageService(HomeLibraryDbContext context) : base(context) { }
    }
}
