using HomeLibrary.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.Interfaces
{
    public interface ITagService
    {
        Task<ICollection<Tag>> GetAllAsync();
        Task<Tag> GetByNameAsync(string name);
        Task<Tag> AddAsync(Tag tag);
        Task UpdateAsync(Tag entity);
        Task DeleteAsync(string name);
        Task DeleteAsync(Tag tag);
    }
}
