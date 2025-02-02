using EmployeeManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagementSystem.Infrastructure.Persistence.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.LastName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.DocumentNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(e => e.DateOfBirth)
                   .IsRequired();

            builder.HasOne<Role>()
                   .WithMany()
                   .HasForeignKey(e => e.Role);
        }
    }
}
