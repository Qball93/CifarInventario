using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CifarInventario.ViewModels.Classes
{
    public class Hasher
    {
        


        public static string Encrypt(string password, string salt)
        {
            if (salt == null)
                salt = "";

            byte[] plainData = ASCIIEncoding.UTF8.GetBytes(password);
            byte[] saltData = ASCIIEncoding.UTF8.GetBytes(salt);
            byte[] plainDataAndSalt = new byte[plainData.Length + salt.Length];

            for (int x = 0; x < plainData.Length; x++)
                plainDataAndSalt[x] = plainData[x];
            for (int n = 0; n < saltData.Length; n++)
                plainDataAndSalt[plainData.Length + n] = saltData[n];

            byte[] hashValue = null;
            SHA256Managed sha = new SHA256Managed();
            hashValue = sha.ComputeHash(plainDataAndSalt);
            sha.Dispose();


            return Convert.ToBase64String(hashValue);
        }

        public static string generateSalt()
        {

            int minSaltLength = 10;
            int maxSaltLength = 16;


            Random r = new Random();
            int SaltLength = r.Next(minSaltLength, maxSaltLength);
            byte[] SaltBytes = new byte[SaltLength];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetNonZeroBytes(SaltBytes);
            rng.Dispose();
            return Convert.ToBase64String(SaltBytes);


        }


    }
}
