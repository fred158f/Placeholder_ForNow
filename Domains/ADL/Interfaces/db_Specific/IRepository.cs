using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ADL.Interfaces.db_Specific
{
    public interface IRepository<T>
    {
        T Add(T entity);
        void AddRange(IEnumerable<T> entity);
        T Update(T entity);
        T Delete(T entity);
        T Get(int id);
        Task<T> GetAsync(int id);
        T SingleOrDefault(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
