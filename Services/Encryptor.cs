using System.Security.Cryptography;
using System.Text;

namespace HostBooking.Services
{
    public class Encryptor
    {
        public static string GetHashString(string s)
        {
            var bytes = Encoding.UTF8.GetBytes(s);

            var CSP =
                new MD5CryptoServiceProvider();

            var byteHash = CSP.ComputeHash(bytes);

            var hash = string.Empty;

            foreach (var b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }
    }
}