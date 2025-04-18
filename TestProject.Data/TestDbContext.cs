using Microsoft.EntityFrameworkCore;
using TestProject.Data.Models;

namespace TestProject.Data;

public class TestDbContext : DbContext
{
    public TestDbContext()
    {
        //Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<MessageData> Messages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite("Data Source=TestDb.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MessageDataConfig).Assembly);
    }
}
