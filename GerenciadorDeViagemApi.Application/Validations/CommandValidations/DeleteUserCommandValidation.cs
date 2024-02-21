using FluentValidation;
using GerenciadorDeViagemApi.Application.Command.DeleteUserCommand;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidaditons
{
    public class DeleteUserCommandValidation : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserCommandValidation()
        {
            RuleFor(x => x.Matricula)
            .NotNull().WithMessage("Matricula não pode ser nulo")
            .NotEmpty().WithMessage("Matricula não pode ser vazio")
            .Must(IsNum).WithMessage("Matricula inválida");

        }
        private bool IsNum(long num)
         => num is long or is int;

    }
}
