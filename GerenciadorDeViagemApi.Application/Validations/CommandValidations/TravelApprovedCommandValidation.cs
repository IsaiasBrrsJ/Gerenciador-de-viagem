using FluentValidation;
using GerenciadorDeViagemApi.Application.Command.TravelApprovedCommand;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidations
{
    public class TravelApprovedCommandValidation : AbstractValidator<TravelApprovedCommand>
    {
        public TravelApprovedCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Informe o ID")
                .NotEmpty().WithMessage("Informe o ID");
        }
    }
}
