using FluentValidation;
using GerenciadorDeViagem.Model.Enum;
using GerenciadorDeViagemApi.Application.Command.CreateUserCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidaditons
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation()
        {
            RuleFor(x => x.Email)
           .EmailAddress()
           .WithMessage("Email: email deve ser válido")
           .MaximumLength(100)
           .WithMessage("Email: deve ter no máximo 100 caracteres")
           .NotEmpty()
           .WithMessage("Email: não pode ser vazio")
           .NotNull()
           .WithMessage("Email> não deve ser nulo");


            RuleFor(x => x.TipoDeUsuario)
            .NotNull()
            .WithMessage("Tipo de usuario: não pode ser nulo")
            .NotEmpty()
            .WithMessage("Tipo de usuario: não pode ser vazio")
            .IsInEnum()
            .WithMessage("Tipo Usuario: Informe o tipo de usuario");

            RuleFor(x => x.Matricula.ToString())
           .NotEmpty().WithMessage("Matrícula solicitante não pode ser vazia")
           .NotNull().WithMessage("Matrícula solicitante não pode ser nula")
           .Length(4, 10).WithMessage("Matrícula solicitante deve ter entre 4 e 10 caracteres");
        }
    }
}
