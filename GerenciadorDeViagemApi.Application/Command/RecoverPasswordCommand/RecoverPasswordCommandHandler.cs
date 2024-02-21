using GerenciadorDeViagemApi.Core.Enums;
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.RecoverPasswordCommand
{
    public class RecoverPasswordCommandHandler : IRequestHandler<RecoverPasswordCommand, bool>
    {
        private readonly IEmailService _emailService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEmailServiceFactory _emailServiceFactory;

        public RecoverPasswordCommandHandler(IEmailService emailService, IUsuarioRepository usuarioRepository, IEmailServiceFactory emailServiceFactory)
        {
            _emailService = emailService;
            _usuarioRepository = usuarioRepository;
            _emailServiceFactory = emailServiceFactory;
        }

        public async Task<bool> Handle(RecoverPasswordCommand request, CancellationToken cancellationToken)
        {

            var emailDTO =await _usuarioRepository.GetUserByEmail(request.Email);

            if (emailDTO == null) { return false; }

            var emailTemplate = _emailServiceFactory.GetService(EmailTemplate.RecuperarSenha);

            emailDTO.EmailTemplate = await emailTemplate.GenerateTemplate(emailDTO);

            var result = await _emailService.SendEmailAsync(emailDTO);

            return result;
        }
    }
}
