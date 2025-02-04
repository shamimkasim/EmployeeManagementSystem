using EmployeeManagementSystem.Domain.Entities;
using EmployeeManagementSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EmployeeManagementSystem.Tests.Infrastructure
{
    public class EmployeeRepositoryTests
    {
        private AppDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique in-memory DB per test
                .Options;
            return new AppDbContext(options);
        }

        [Fact]
        public async Task AddEmployeeAsync_Should_Add_Employee_To_Database()
        {
            // Arrange
            var dbContext = GetDbContext();
            var repository = new EmployeeRepository(dbContext);
            var employee = new Employee("John Doe", "john.doe@example.com", 5000);

            // Act
            var result = await repository.AddEmployeeAsync(employee);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().NotBeEmpty();
            (await dbContext.Employees.CountAsync()).Should().Be(1);
        }

        [Fact]
        public async Task GetAllEmployeesAsync_Should_Return_All_Employees()
        {
            // Arrange
            var dbContext = GetDbContext();
            var repository = new EmployeeRepository(dbContext);
            await repository.AddEmployeeAsync(new Employee("John Doe", "john.doe@example.com", 5000));
            await repository.AddEmployeeAsync(new Employee("Jane Doe", "jane.doe@example.com", 6000));

            // Act
            var employees = await repository.GetAllEmployeesAsync();

            // Assert
            employees.Should().HaveCount(2);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_Should_Return_Correct_Employee()
        {
            // Arrange
            var dbContext = GetDbContext();
            var repository = new EmployeeRepository(dbContext);
            var employee = new Employee("John Doe", "john.doe@example.com", 5000);
            await repository.AddEmployeeAsync(employee);

            // Act
            var result = await repository.GetEmployeeByIdAsync(employee.Id);

            // Assert
            result.Should().NotBeNull();
            result?.Id.Should().Be(employee.Id);
        }

        [Fact]
        public async Task DeleteEmployeeAsync_Should_Remove_Employee_From_Database()
        {
            // Arrange
            var dbContext = GetDbContext();
            var repository = new EmployeeRepository(dbContext);
            var employee = new Employee("John Doe", "john.doe@example.com", 5000);
            await repository.AddEmployeeAsync(employee);

            // Act
            await repository.DeleteEmployeeAsync(employee.Id);
            var result = await repository.GetEmployeeByIdAsync(employee.Id);

            // Assert
            result.Should().BeNull();
            (await dbContext.Employees.CountAsync()).Should().Be(0);
        }
    }
}
