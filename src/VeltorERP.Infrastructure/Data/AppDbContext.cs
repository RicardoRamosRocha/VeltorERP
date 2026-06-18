using Microsoft.EntityFrameworkCore;
using VeltorERP.Domain.Entities;

namespace VeltorERP.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<ServiceOrder> ServiceOrders { get; set; }

    public DbSet<ServiceOrderItem> ServiceOrderItems { get; set; }
}