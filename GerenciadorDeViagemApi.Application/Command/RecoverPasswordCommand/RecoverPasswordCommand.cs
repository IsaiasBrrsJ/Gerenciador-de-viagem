using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.RecoverPasswordCommand
{
    public class RecoverPasswordCommand : IRequest<bool>
    {
        public string Email { get; set; } = default!;
    }
}
