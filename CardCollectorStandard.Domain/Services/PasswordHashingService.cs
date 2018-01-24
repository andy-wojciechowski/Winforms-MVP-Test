using System;
using System.Security.Cryptography;

namespace CardCollectorStandard.Domain.Services
{
    public interface IPasswordHashingService
    {
        bool ValidatePassword(string password, string savedHash);
        Tuple<string, string> CreateHash(string password);
    }
    public class PasswordHashingService : IPasswordHashingService
    {
        public Tuple<string, string> CreateHash(string password)
        {
            return this.ComputeHash(password);
        }

        public bool ValidatePassword(string password, string savedHash)
        {
            var computedHash = this.ComputeHash(password);

            if (savedHash.Equals(computedHash.Item2))
                return true;
            return false;
        }

        private Tuple<string, string> ComputeHash(string password)
        {
            //Modeled from https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129#10402129
            //Create the salt
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //Get the hash value
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            //Combine the salt and password bytes
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return new Tuple<string, string>(Convert.ToBase64String(salt), Convert.ToBase64String(hashBytes));
        }
    }
}
