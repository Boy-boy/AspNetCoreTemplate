using Core.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Template.Domain.Entities;

namespace Template.EntityFramework
{
    public class TemplateDbContext : CoreDbContext
    {
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Payment> Payments { get; set; }
    }
}
