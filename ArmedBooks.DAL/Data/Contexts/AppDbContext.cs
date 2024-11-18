using ArmedBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArmedBooks.DAL.Data.Contexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
}
