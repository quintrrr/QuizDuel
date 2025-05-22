using System.Security.Cryptography;
using System.Text;

namespace QuizDuel.Core.Services
{
    public class PasswordService : IPasswordService
    {
        public string GenerateSalt()
        {
            var salt = new byte[32];
            using (var rand = RandomNumberGenerator.Create())
            {
                rand.GetBytes(salt);
            }
            var saltString = Convert.ToBase64String(salt);
            return saltString;
        }

        public string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = password + salt;
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                var hashResult = Convert.ToBase64String(bytes);
                return hashResult;
            }
        }
    }
}
