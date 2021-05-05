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
        public async Task<List<T>> GetList()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
