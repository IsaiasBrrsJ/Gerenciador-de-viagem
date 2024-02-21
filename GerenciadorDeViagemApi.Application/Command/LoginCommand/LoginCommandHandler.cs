using GerenciadorDeViagemApi.Core.Repositories;
using GerenciadorDeViagemApi.Core.Services;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, (string token, bool? primeiroAcesso)>
    {
        private readonly IUsuarioRepository _usuarioRepository = default!;
        private readonly IHashPasswordServices _computeHash256 = default!;
        private readonly IAuthServices _auth = default!;

        public LoginCommandHandler(IUsuarioRepository usuarioRepository, IHashPasswordServices computeHash256, IAuthServices auth)
        {
            _usuarioRepository = usuarioRepository;
            _computeHash256 = computeHash256;
            _auth = auth;
        }

        public async Task<(string token, bool? primeiroAcesso)> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var covertToHash = _computeHash256.ComputerHash256(request.Password);

            var user = await _usuarioRepository.LoginUserAsync(request.Matricula, covertToHash);
         
            if (user == null)
                return (String.Empty, null);

            var twoHours = 2;

            var token = _auth.GenerateJwtToken(user.Email, user.TipoDeUsuario, TimeSpan.FromHours(twoHours));

            return (token, user.PrimeiroAcesso);

        }
    }
}
