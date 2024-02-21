using GerenciadorDeViagemApi.Core.EmailTemplates;
using GerenciadorDeViagemApi.Core.Enums;
using GerenciadorDeViagemApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeViagemApi.Infrastructure.Services
{
    public class EmailServiceFactory : IEmailServiceFactory
    {
        private readonly AlertaAlteracaoSenha _alertaAlteracaoSenha;
        private readonly PrimeiroAcesso _primeiroAcesso;
        private readonly RecuperacaoDeSenha _recuperacaoDeSenha;

        public EmailServiceFactory(
            [FromServices] AlertaAlteracaoSenha alertaAlteracaoSenha,
            [FromServices] PrimeiroAcesso primeiroAcesso,
            [FromServices] RecuperacaoDeSenha recuperacaoDeSenha)
        {
            _alertaAlteracaoSenha = alertaAlteracaoSenha;
            _primeiroAcesso = primeiroAcesso;
            _recuperacaoDeSenha = recuperacaoDeSenha;
        }

        public IEmailTemplateServices GetService(EmailTemplate emailTemplate)
         => emailTemplate switch
         {
             EmailTemplate.PrimeiroAcesso => _primeiroAcesso,
             EmailTemplate.RecuperarSenha => _recuperacaoDeSenha,
             EmailTemplate.AlertaAlteracaoDeSenha => _alertaAlteracaoSenha,
             _ => throw new InvalidOperationException()
         };

      
    }
}
