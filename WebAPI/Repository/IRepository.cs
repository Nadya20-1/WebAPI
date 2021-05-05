using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> GetList();
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
