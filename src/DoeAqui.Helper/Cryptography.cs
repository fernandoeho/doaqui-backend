using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace DoeAqui.Helper
{
    public static class Cryptography
    {
        public static string Salt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public static string Hash(string password, string salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
            ));

            return hashed;
        }
    }
}