using GerenciadorDeViagemApi.Core.Enums;
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.UpdatePasswordCommand
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand, string>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IHashPasswordServices _hashPassword;
        private readonly IEmailService _emailService;
        private readonly IEmailServiceFactory _emailServiceFactory = default!;

        public UpdatePasswordCommandHandler(IUsuarioRepository usuarioRepository, IHashPasswordServices hashPassword, IEmailService emailService, IEmailServiceFactory emailServiceFactory)
        {
            _usuarioRepository = usuarioRepository;
            _hashPassword = hashPassword;
            _emailService = emailService;
            _emailServiceFactory = emailServiceFactory;
        }

        public async Task<string> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var oldPasswordHash = _hashPassword.ComputerHash256(request.OldPassword);
            var newPasswordHash = _hashPassword.ComputerHash256(request.NewPassword);

           var emailDTO = await _usuarioRepository.UpdatePassword(request.Matricula, oldPasswordHash, newPasswordHash);

            if (emailDTO is null)
                return null!;


            var emailService = _emailServiceFactory.GetService(EmailTemplate.AlertaAlteracaoDeSenha);

            emailDTO.EmailTemplate = await emailService.GenerateTemplate(emailDTO);

            await _emailService.SendEmailAsync(emailDTO);
                                      
            return emailDTO.NomeCompleto;
        }
    }
}
