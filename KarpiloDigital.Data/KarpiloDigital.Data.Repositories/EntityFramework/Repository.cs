using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace KarpiloDigital.Data.Repositories.EntityFramework
{
    public class Repository<T, K> : IRepository<T>
        where T : class, IEntity
        where K : DbContext, new()
    {
        protected DbContext db;
        public Repository()
        {
            db = new K();
        }

        public void Add(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Remove(T entity)
        {
            db.Set<T>().Attach(entity);
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();
        }

        public IQueryable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return db.Set<T>();
        }

        public T GetById(Int32 id)
        {
            return db.Set<T>().Single(e => e.ID == id);
        }
    }
}
