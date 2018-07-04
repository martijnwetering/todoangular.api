using ToDoAngular.Api.Contract;
using ToDoAngular.Api.Models;

namespace ToDoAngular.Api.Infrastructure
{
    public class TodoAngularTodoAngularUoW : ITodoAngularUoW
    {
        private readonly TodoAngularDbContext _ctx;

        public TodoAngularTodoAngularUoW(TodoAngularDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public IRepository<Todo> Todos => new EFCoreRepository<Todo>(_ctx);
    }
}