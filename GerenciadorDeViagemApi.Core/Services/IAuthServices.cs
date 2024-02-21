using GerenciadorDeViagem.Model.Enum;

namespace GerenciadorDeViagemApi.Core.Services
{
    public interface IAuthServices
    {
        string GenerateJwtToken(string email, TipoDeUsuario role, TimeSpan expiryTime);
    }
}
