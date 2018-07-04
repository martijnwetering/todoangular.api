using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ToDoAngular.Api.Models;

namespace ToDoAngular.Api.Infrastructure
{
    public class TodoAngularDbContext : DbContext
    {
        public TodoAngularDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}