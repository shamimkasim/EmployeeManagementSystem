using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagementSystem.Application.Interfaces;
using EmployeeManagementSystem.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeManagementSystem.Infrastructure.Auth
{
    public class JwtTokenGenerator : IJwtTokenGenerator
    {
        private readonly IConfiguration _configuration;

        public JwtTokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(Employee employee)
        {
            if (employee == null)
                throw new ArgumentNullException(nameof(employee), "Employee object cannot be null");

            var secretKey = _configuration["Jwt:SecretKey"];
            if (string.IsNullOrEmpty(secretKey) || secretKey.Length < 32)
                throw new ArgumentException("JWT Secret Key must be at least 32 characters long. Update `appsettings.json`.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.UtcNow.AddMinutes(60);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: new List<Claim>
                {
                new Claim(JwtRegisteredClaimNames.Sub, employee.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, employee.Email),
                new Claim("role", employee.RoleId.ToString())
                },
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}