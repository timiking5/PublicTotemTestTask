using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Category> Category { get; set; }
    public DbSet<ExpenditureRecord> ExpenditureRecord { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Food" },
                new Category { Id = 2, Name = "Transport" },
                new Category { Id = 3, Name = "Mobile Connection" },
                new Category { Id = 4, Name = "Internet Connection" },
                new Category { Id = 5, Name = "Entertainment" }
                );
        modelBuilder.Entity<ExpenditureRecord>().HasData(
            new ExpenditureRecord
            {
                Id = 1,
                Amount = 1000,
                CategoryId = 1,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            }
            );
    }
}
