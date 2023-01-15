using ADL.Interfaces.db_Specific;
using AIL.idh.sql.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIL.idh.sql.Repositories
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly DataSourceContext _dbContext;

        public GenericRepository(DataSourceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T Add(T entity)
        {
            return _dbContext.Add(entity).Entity;
        }

        public virtual void AddRange(IEnumerable<T> entity)
        {
            _dbContext.AddRange(entity);
        }

        public virtual T Update(T entity)
        {
            return _dbContext.Update(entity).Entity;
        }

        public virtual T Delete(T entity)
        {
            return _dbContext.Remove(entity).Entity;
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().SingleOrDefault(predicate);
        }

        public virtual async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public virtual T Get(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public virtual async Task<T> GetAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public virtual IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>().AsQueryable().Where(predicate).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>().AsQueryable().Where(predicate).ToListAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}


