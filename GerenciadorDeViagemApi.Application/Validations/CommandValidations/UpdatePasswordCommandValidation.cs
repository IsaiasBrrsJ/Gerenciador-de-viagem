using FluentValidation;
using GerenciadorDeViagemApi.Application.Command.UpdatePasswordCommand;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidaditons
{
    public class UpdatePasswordCommandValidation : AbstractValidator<UpdatePasswordCommand>
    {
        public UpdatePasswordCommandValidation()
        {
            RuleFor(x => x.Matricula)
                .NotEmpty().WithMessage("Matricula não pode ser vazia")
                .NotNull().WithMessage("Matricula não pode ser nula")
             
                .Must(MaxLenth).WithMessage("Matricula incorreta");
        }

      

        private bool MaxLenth(long num)
        {
            return num.ToString().Length is not 4 or > 10;
        }
    }
}
