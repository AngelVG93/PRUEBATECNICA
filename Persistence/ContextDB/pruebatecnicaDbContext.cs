using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Persistence.ContextDB
{
    public class pruebatecnicaDbContext(DbContextOptions<pruebatecnicaDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Product> product { get; set; }
        public virtual DbSet<Order> orderapp { get; set; }
        public virtual DbSet<OrderProduct> orderapp_foodapp { get; set; }
        public virtual DbSet<Permissions> permissionsapp { get; set; }
        public virtual DbSet<Role> roleapp { get; set; }
        public virtual DbSet<RoleUser> roleapp_userapp { get; set; }
        public virtual DbSet<User> userapp { get; set; }
        public virtual DbSet<UserOrder> userapp_orderapp { get; set; }
        public virtual DbSet<LogException> logexception { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
