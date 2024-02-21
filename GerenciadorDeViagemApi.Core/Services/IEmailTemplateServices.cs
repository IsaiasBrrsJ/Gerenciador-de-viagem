using GerenciadorDeViagemApi.Core.DTOs;

namespace GerenciadorDeViagemApi.Core.Services
{
    public interface IEmailTemplateServices
    {
        Task<string> GenerateTemplate(EmailDTO emailDTO);
    }
}
