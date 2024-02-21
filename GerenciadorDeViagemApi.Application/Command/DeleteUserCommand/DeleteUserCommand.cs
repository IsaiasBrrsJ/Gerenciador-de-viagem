using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(long matricula)
        {
            Matricula = matricula;
        }

        public long Matricula { get; init; }
    }
}
