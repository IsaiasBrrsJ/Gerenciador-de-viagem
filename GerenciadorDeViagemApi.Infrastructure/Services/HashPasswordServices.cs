using GerenciadorDeViagemApi.Core.Services;
using System.Security.Cryptography;
using System.Text;

namespace GerenciadorDeViagemApi.Infrastructure.Services
{
    public class HashPasswordServices : IHashPasswordServices
    {
        public string ComputerHash256(string password)
        {
            var passwordHash = new StringBuilder();
          using(var sha256 = SHA256.Create())
          {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (var i = 0; i < bytes.Length; i++)
                {
                    passwordHash.Append(bytes[i].ToString("X2"));
                }

               return passwordHash.ToString();
          }
        }
    }
}
