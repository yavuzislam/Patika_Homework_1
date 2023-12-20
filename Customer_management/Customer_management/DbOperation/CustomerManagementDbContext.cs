using Customer_management.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer_management.DbOperation;

public class CustomerManagementDbContext : DbContext
{
    public CustomerManagementDbContext(DbContextOptions<CustomerManagementDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
}