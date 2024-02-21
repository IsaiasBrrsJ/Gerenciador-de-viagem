using FluentValidation;
using GerenciadorDeViagemApi.Application.Command.LoginCommand;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidaditons
{
    public class LoginCommandValidation : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(x => x.Matricula.ToString())
            .NotEmpty().WithMessage("Matrícula solicitante não pode ser vazia")
            .NotNull().WithMessage("Matrícula solicitante não pode ser nula")
            .Length(4, 10).WithMessage("Matrícula solicitante deve ter entre 4 e 10 caracteres");

            RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("Password: Informe sua senha")
            .NotEmpty()
            .WithMessage("Password: Informe sua senha");
        }
    }
}
