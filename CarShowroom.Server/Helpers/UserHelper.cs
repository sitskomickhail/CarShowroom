using System.Security.Cryptography;
using System.Text;

namespace CarShowroom.Server.Helpers
{
    public static class UserHelper
    {
        public static string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Encoding.UTF8.GetString(salt);
        }

        public static string GenerateHash(string password, string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
                new byte[passwordBytes.Length + salt.Length];

            for (int i = 0; i < passwordBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = passwordBytes[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[passwordBytes.Length + i] = saltBytes[i];
            }

            return Encoding.UTF8.GetString(algorithm.ComputeHash(plainTextWithSaltBytes));
        }

        public static bool IsPasswordValid(string password, string hash, string salt)
        {
            return hash == GenerateHash(password, salt);
        }
    }
}