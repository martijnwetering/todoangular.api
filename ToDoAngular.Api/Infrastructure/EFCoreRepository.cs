using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToDoAngular.Api.Contract;

namespace ToDoAngular.Api.Infrastructure
{
    public class EFCoreRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<T> _dbSet;

        public EFCoreRepository(DbContext ctx)
        {
            if (ctx == null) throw new ArgumentNullException(nameof(ctx));

            _ctx = ctx;
            _dbSet = _ctx.Set<T>();
        }

        public void Add(T entity)
        {
            var dbEntityEntry = _ctx.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                _dbSet.Add(entity);
            }
        }

        public void Update(int id, T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            var dbEntry = _ctx.Entry(entity);
            if (dbEntry.State != EntityState.Deleted)
            {
                dbEntry.State = EntityState.Deleted;
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Remove(entity);
            }
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            if (entity == null)
            {
                return;
            }
            Delete(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
    }
}