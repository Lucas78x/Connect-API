
using System.Security.Cryptography;
using System.Text;

namespace Connect.Utils
{
    public class SHA256Encrypt
    {

        public static string Encrypt(string rawData)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                var builder = new StringBuilder();
                foreach (var t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
