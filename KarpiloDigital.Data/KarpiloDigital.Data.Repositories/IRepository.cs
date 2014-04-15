using System;
using System.Linq;
using System.Linq.Expressions;

namespace KarpiloDigital.Data.Repositories
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetById(Int32 id);
    }
}
