using FluentValidation;
using GerenciadorDeViagemApi.Application.Querie.GetTravelId;

namespace GerenciadorDeViagemApi.Application.Validations.QuerieValidations
{
    public class GetTravelMatriculaQueryValidation : AbstractValidator<GetTravelQuery>
    {
        public GetTravelMatriculaQueryValidation()
        {

            RuleFor(x => x.Matricula.ToString())
           .NotEmpty().WithMessage("Matrícula solicitante não pode ser vazia")
           .NotNull().WithMessage("Matrícula solicitante não pode ser nula")
           .Length(4, 10).WithMessage("Matrícula solicitante deve ter entre 4 e 10 caracteres");

        }
    }
}
