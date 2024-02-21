using GerenciadorDeViagemApi.Core.Enums;

namespace GerenciadorDeViagemApi.Core.Services
{
    public interface IEmailServiceFactory
    {
        IEmailTemplateServices GetService(EmailTemplate emailTemplate);
    }
}
