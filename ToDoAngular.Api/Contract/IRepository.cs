using System;
using System.Linq;

namespace ToDoAngular.Api.Contract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(int id, T entity);
        void Delete(int id);
        void Delete(T entity);
    }
}