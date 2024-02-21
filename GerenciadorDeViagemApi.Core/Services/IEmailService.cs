using GerenciadorDeViagemApi.Core.DTOs;

namespace GerenciadorDeViagemApi.Core.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(EmailDTO email);
    }
}
