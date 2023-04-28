using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Service.Extensions
{
    public static class stringExtensions
    {
        public static string Encrypt(this string password)
        {
            HashAlgorithm sha256Hash = SHA256.Create();

            byte[] hashBytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            var hashPassword = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            return hashPassword;
        }
    }
}