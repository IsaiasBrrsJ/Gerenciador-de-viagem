using FluentValidation;
using GerenciadorDeViagemApi.Application.Command.TravelApprovedCommand;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidations
{
    public class TravelCancelCommandValidation : AbstractValidator<TravelApprovedCommand>
    {
        public TravelCancelCommandValidation()
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Informe o ID")
              .NotEmpty().WithMessage("Informe o ID");
        }
    }
}
