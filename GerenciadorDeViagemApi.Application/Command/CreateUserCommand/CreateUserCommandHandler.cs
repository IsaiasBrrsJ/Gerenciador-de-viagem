using GerenciadorDeViagem.Model;
using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Enums;
using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository = default!;
        private readonly IHashPasswordServices _computeHash256 = default!;
        private readonly IEmailService _emailService = default!;
        private readonly IEmailServiceFactory _emailServiceFactory = default!;

        public CreateUserCommandHandler(
            IUsuarioRepository usuarioRepository, IHashPasswordServices computeHash256, 
            IEmailService emailService, IEmailServiceFactory emailServiceFactory
            )
        {
            _usuarioRepository = usuarioRepository;
            _computeHash256 = computeHash256;
            _emailService = emailService;
            _emailServiceFactory = emailServiceFactory;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var errorInAdd = -1;

            if (request is null)
                return errorInAdd;

            request.Email = request.Email.ToLower();

            var user = new Usuario(request.Matricula, request.NomeCompleto, request.Email, request.TipoDeUsuario);

            var passToEmail = user.Senha;
            var passToHash = _computeHash256.ComputerHash256(user.Senha);

            user.ConvertPassToHash(passToHash);

            var id = await _usuarioRepository.AddUserAsync(user);

            if(id is not 0 or > 0)
            {
                 var getEmailTemplate = _emailServiceFactory.GetService(EmailTemplate.PrimeiroAcesso);

                 var emailDTO = new EmailDTO(user.NomeCompleto, user.Email, user.TipoDeUsuario, "Primeiro Acesso", user.Matricula, passToEmail);

                 emailDTO.EmailTemplate = await getEmailTemplate.GenerateTemplate(emailDTO);

                  await _emailService.SendEmailAsync(emailDTO);

                return id;
            }

            return errorInAdd;
        }
    }
}
