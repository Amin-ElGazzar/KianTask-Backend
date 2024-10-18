using Kian.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kian.Context;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employees> Employees { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}
