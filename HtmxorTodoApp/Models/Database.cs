using Microsoft.EntityFrameworkCore;

namespace HtmxorTodoApp.Models;

public class Database(DbContextOptions<Database> options) : DbContext(options)
{
    public DbSet<TodoItem> Items => Set<TodoItem>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlite("Data Source=app.db")
            .EnableSensitiveDataLogging()
            .LogTo(
                Console.WriteLine,
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information);
    }
}

