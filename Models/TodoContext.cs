using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
  public class TodoContext : DbContext
  {
    public TodoContext(DbContextOptions<TodoContext> options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }
  }
}