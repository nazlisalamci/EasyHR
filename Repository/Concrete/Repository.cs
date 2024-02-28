using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Abstract;
using Repository.Connection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class Repository<T> :IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public Repository( AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            try {
                var result = await _context.Set<T>().AddAsync(entity);
                return result.Entity;
            }catch (Exception ex)
            {
                throw;
            }
        }
        public T Add(T entity)
        {
            try
            {
                var result = _context.Set<T>().Add(entity);
                return (T)result.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().AddRange(entities);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Update(T entity)
        {
            try
            {
                var result = _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Delete(T entity)
        {
            try
            {
               _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> exception)
        {
            try
            {
                return await Task.Run(() => _context.Set<T>().Where(exception).ToListAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await Task.Run(() => _context.Set<T>().ToListAsync());
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<T> GetByAsync(Expression<Func<T, bool>> exception)
        {
            try
            {
                return await Task.Run(() => _context.Set<T>().FirstOrDefault(exception));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<int> GetCountAsync(Expression<Func<T, bool>> exception)
        {
            try
            {
                return await Task.Run(() => _context.Set<T>().Count(exception));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task SaveChanges()
        {
            try {
           await _context.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw;
            }
        }
        public async Task Dispose()
        {
            try
            {
              await  _context.DisposeAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
