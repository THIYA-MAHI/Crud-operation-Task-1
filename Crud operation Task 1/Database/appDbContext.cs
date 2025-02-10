
using Crud_operation_Task_1.Entity;
using Microsoft.EntityFrameworkCore;

namespace Crud_operation_Task_1.Database
{
    public class appDbContext:DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
