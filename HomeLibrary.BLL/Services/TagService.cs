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
    public class TagService : GenericService<Tag>, ITagService
    {
        public TagService(HomeLibraryDbContext context) : base(context) { }
    }
}
