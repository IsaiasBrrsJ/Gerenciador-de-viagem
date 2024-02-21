using FluentValidation;
using GerenciadorDeViagemApi.Application.Command.RecoverPasswordCommand;
using System.Text.RegularExpressions;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidaditons
{
    public class RecoverPasswordCommandValidation : AbstractValidator<RecoverPasswordCommand>
    {
        public RecoverPasswordCommandValidation()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email não pode ser vazio")
                .NotNull().WithMessage("Email não pode ser nulo")
                .Must(IsEmail).WithMessage("Email inválido");
        }
        public bool IsEmail(string email)
        {
            var regex = @"^[A-Za-z]{1,}[a-zA-Z0-9._%+-]+@(gmail\.com|hotmail\.com|outlook.com|yahoo.com)(?:\.br|\.BR)?$";

            return Regex.IsMatch(email, regex);
        }
    }
}
