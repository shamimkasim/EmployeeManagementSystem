using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Domain.ValueObjects;
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

            builder.Property(e => e.RoleId)
                   .IsRequired();

            
            builder.OwnsOne(e => e.PhoneNumber, phone =>
            {
                phone.Property(p => p.Number)   
                     .HasColumnName("PhoneNumber")
                     .IsRequired();
            });

             
            builder.HasOne(e => e.Role)
                   .WithMany()
                   .HasForeignKey(e => e.RoleId);
        }
    }
}
