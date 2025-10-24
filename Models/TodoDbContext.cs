using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Models
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<GroceryItem> GroceryItems { get; set; }
        public DbSet<Goal> Goals { get; set; }
    }
}