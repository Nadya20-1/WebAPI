using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly FridgeDBContext _context;
        public Repository(FridgeDBContext context)
        {
            this._context = context;
        }
        public async Task<List<T>> GetListAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var product = await _context.FridgeProducts.FindAsync(id);
            _context.FridgeProducts.Remove(product);
            await _context.SaveChangesAsync();
            return id;
        }
    }
}
