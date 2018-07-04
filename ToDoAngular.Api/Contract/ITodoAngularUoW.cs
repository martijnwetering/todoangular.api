using ToDoAngular.Api.Models;

namespace ToDoAngular.Api.Contract
{
    public interface ITodoAngularUoW
    {
        void Commit();

        IRepository<Todo> Todos { get; }
    }
}