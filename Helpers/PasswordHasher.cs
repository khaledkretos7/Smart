using System;
using System.Security.Cryptography;
using System.Text;

namespace SmartCity.Helpers
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            var hashOfInput = HashPassword(enteredPassword);
            return hashOfInput == storedHash;
        }
    }
}
