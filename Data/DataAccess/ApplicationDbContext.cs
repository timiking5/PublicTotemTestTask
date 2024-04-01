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
                Amount = 4000,
                CategoryId = 1,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            },
            new ExpenditureRecord
            {
                Id = 2,
                Amount = 3000,
                CategoryId = 1,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            },
            new ExpenditureRecord
            {
                Id = 3,
                Amount = 2000,
                CategoryId = 1,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            },
            new ExpenditureRecord
            {
                Id = 4,
                Amount = 1000,
                CategoryId = 2,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            },
            new ExpenditureRecord
            {
                Id = 5,
                Amount = 1500,
                CategoryId = 3,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            },
            new ExpenditureRecord
            {
                Id = 6,
                Amount = 1200,
                CategoryId = 4,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            },
            new ExpenditureRecord
            {
                Id = 7,
                Amount = 6000,
                CategoryId = 5,
                Date = new DateTime(2024, 03, 31),
                Description = "Some spends"
            },
            new ExpenditureRecord
            {
                Id = 8,
                Amount = 10000,
                CategoryId = 1,
                Date = new DateTime(2024, 02, 29),
                Description = "Extra hungry"
            },
            new ExpenditureRecord
            {
                Id = 9,
                Amount = 8000,
                CategoryId = 5,
                Date = new DateTime(2024, 02, 29),
                Description = "Extra hungry"
            }
            );
    }
}
