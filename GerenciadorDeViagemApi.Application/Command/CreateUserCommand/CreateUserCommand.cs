using GerenciadorDeViagem.Model.Enum;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.CreateUserCommand
{
    public class CreateUserCommand : IRequest<int>
    {
        public long Matricula { get; set; }
        public string Email { get; set; } = default!;
        public string NomeCompleto { get; set; } = default!;
        public TipoDeUsuario TipoDeUsuario { get; set; }

    }
}
