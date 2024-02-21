using FluentValidation;
using GerenciadorDeViagemApi.Application.Querie.GetTravelId;

namespace GerenciadorDeViagemApi.Application.Validations.QuerieValidations
{
    public class GetTravelIdQueryValidation : AbstractValidator<GetTravelIdQuery>
    {
        public GetTravelIdQueryValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID não pode ser vazio")
                .NotNull().WithMessage("ID não pode ser nulo");
        }
    }
}
