using HomeLibrary.BLL.Interfaces;
using HomeLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.BLL.Services
{
    //TODO: Try to use second parament(Dto) as retuned value method
    public abstract class GenericService<T> : IGenericService<T> where T: class
    {
        protected readonly HomeLibraryDbContext dbContext;
        public GenericService(HomeLibraryDbContext context)
        {
            dbContext = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T entity = await GetByIdAsync(id);
            if(entity != null) await DeleteAsync(entity);
        }

        public async Task DeleteAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        //TODO: Test update
        public async Task UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            //dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
