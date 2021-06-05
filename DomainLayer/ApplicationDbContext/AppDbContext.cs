using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainLayer.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
    }
}
