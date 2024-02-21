using GerenciadorDeViagem.Model.Enum;
using GerenciadorDeViagemApi.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GerenciadorDeViagemApi.Infrastructure.Services
{
    public class AuthServices : IAuthServices
    {
        private IConfiguration _configuration = default!;
        public AuthServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string email, TipoDeUsuario role, TimeSpan expiryTime)
        {
            var roleValue = Enum.GetName(typeof(TipoDeUsuario), role);

            var key = _configuration["JwtToken:Key"];
            var audience = _configuration["JwtToken:Audience"];
            var issuer = _configuration["JwtToken:Issuer"];
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));
            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, roleValue!)
            };

            var token = new JwtSecurityToken
            (
                issuer: issuer,
                audience: audience,
                expires: DateTime.Now.Add(expiryTime),
                signingCredentials: credential,
                claims: claims
            );

            var tokenHandler = new JwtSecurityTokenHandler();

            var stringToken = tokenHandler.WriteToken(token);


            return stringToken;

        }

    }
}
