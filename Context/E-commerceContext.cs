using E_Commerce_2.Configurations;
using E_Commerce_2.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_2.Context
{
    public class E_commerceContext : IdentityDbContext<User>
    {
        public E_commerceContext(DbContextOptions options): base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }
        public DbSet<Admin>Admins{get;set;}
        public DbSet<Customer>Customers{get;set;}
    }
}