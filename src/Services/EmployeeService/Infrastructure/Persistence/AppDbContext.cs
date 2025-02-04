using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId);

            
            modelBuilder.Entity<Employee>()
                .OwnsOne(e => e.PhoneNumber, phone =>
                {
                    phone.Property(p => p.Number)
                         .HasColumnName("PhoneNumber")
                         .IsRequired();
                });
        }
    }
}
