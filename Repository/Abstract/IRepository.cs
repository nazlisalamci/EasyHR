using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IRepository<T> where T : class
    {
        void AddRange(IEnumerable<T> entities);
        Task<T> AddAsync(T entity);
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> exception);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByAsync(Expression<Func<T, bool>> exception);
        Task<int> GetCountAsync(Expression<Func<T, bool>> exception);
        Task Dispose();
        Task SaveChanges();
    }
}
