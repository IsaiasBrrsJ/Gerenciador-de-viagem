using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.LoginCommand
{
    public class LoginCommand : IRequest<(string token, bool? primeiroAcesso)>
    {
        public long Matricula { get; set; } 
        public string Password { get; set; } = default!;
    }
}
