using System;
using System.Linq;
using System.Linq.Expressions;

namespace HelloMovies.DataAccess.Interfaces
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Save();
    }
}