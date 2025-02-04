using EmployeeManagementSystem.Application.Interfaces;
using BCrypt.Net;

namespace EmployeeManagementSystem.Infrastructure.Security
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}





//using EmployeeManagementSystem.Application.Interfaces;
//using System.Security.Cryptography;
//using System.Text;
//using BCrypt.Net;

//namespace EmployeeManagementSystem.Infrastructure.Security
//{
//    public class PasswordHasher : IPasswordHasher
//    {
//        public string HashPassword(string password)
//        {
//            using var sha256 = SHA256.Create();
//            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
//            return Convert.ToBase64String(hashedBytes);
//        }

//        public bool VerifyPassword(string password, string hashedPassword)
//        {
//            using var sha256 = SHA256.Create();
//            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
//            var computedHash = Convert.ToBase64String(hashedBytes);

//            return computedHash == hashedPassword;
//        }

//    }
//}
