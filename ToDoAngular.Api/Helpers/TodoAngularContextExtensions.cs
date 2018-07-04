using ToDoAngular.Api.Infrastructure;
using ToDoAngular.Api.Models;

namespace ToDoAngular.Api.Helpers
{
    public static class TodoAngularContextExtensions
    {
        public static void EnsureSeedDataForContext(this TodoAngularDbContext ctx)
        {
            ctx.Todos.RemoveRange(ctx.Todos);
            ctx.SaveChanges();

            Todo[] todos =
            {
                new Todo {Title = "Test todo 1", Completed = false},
                new Todo {Title = "Test todo 2", Completed = false},
                new Todo {Title = "Test todo 3", Completed = false}
            };

            ctx.AddRange(todos);
            ctx.SaveChanges();
        }
    }
}