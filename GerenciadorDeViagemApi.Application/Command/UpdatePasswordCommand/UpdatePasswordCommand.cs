using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.UpdatePasswordCommand
{
    public class UpdatePasswordCommand : IRequest<string>
    {

        public long Matricula { get;  set; }
        public string OldPassword { get; set; } = default!;
        public string NewPassword {  get;  set; } = default!;
    }
}
