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
    public class TagService : ITagService
    {
        private readonly HomeLibraryDbContext _dbContext;
        public TagService(HomeLibraryDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Tag> AddAsync(Tag tag)
        {
            await _dbContext.Tags.AddAsync(tag);
            await _dbContext.SaveChangesAsync();
            return tag;
        }

        public async Task DeleteAsync(string name)
        {
            Tag tag = await GetByNameAsync(name);
            if (tag != null) await DeleteAsync(tag);
        }

        public async Task DeleteAsync(Tag tag)
        {
            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<Tag>> GetAllAsync()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<Tag> GetByNameAsync(string name)
        {
            return await _dbContext.Tags.FindAsync(name);
        }

        public async Task UpdateAsync(Tag entity)
        {
            _dbContext.Tags.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
