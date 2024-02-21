using FluentValidation;
using GerenciadorDeViagemApi.Application.Command.CreateTravelCommand;
using Microsoft.Extensions.Configuration;

namespace GerenciadorDeViagemApi.Application.Validations.CommandValidaditons
{
    public class CreateTravelCommandValidation : AbstractValidator<CreateTravelCommand>
    {
        private readonly string _matriculaSistemica = default!;
        public CreateTravelCommandValidation(IConfiguration configuration)
        {
            _matriculaSistemica = configuration["UsuarioSistemico:Matricula"]!.ToString();


            RuleFor(x => x.Destino)
            .NotNull().WithMessage("Destino não pode ser nulo")
            .NotEmpty().WithMessage("Destino não pode ser vazio");

            RuleFor(x => new { x.MatriculaSolicitante, x.MatriculaAprovador })
            .Must(m => ValidaMatriculas(m.MatriculaSolicitante, m.MatriculaAprovador))
            .WithMessage("Matricula Solicitante não pode ser igual matricula do aprovador")
            .Must(m => ValidaMatriculaAprovador(m.MatriculaAprovador))
            .WithMessage("Matricula Aprovador incorreta");

            RuleFor(x => x.MatriculaSolicitante.ToString())
            .NotEmpty().WithMessage("Matrícula solicitante não pode ser vazia")
            .NotNull().WithMessage("Matrícula solicitante não pode ser nula")
            .Length(4, 10).WithMessage("Matrícula solicitante deve ter entre 4 e 10 caracteres");

            RuleFor(x => x.MatriculaAprovador.ToString())
            .NotEmpty().WithMessage("Matrícula solicitante não pode ser vazia")
            .NotNull().WithMessage("Matrícula solicitante não pode ser nula")
            .Length(4, 10).WithMessage("Matrícula solicitante deve ter entre 4 e 10 caracteres");


            RuleFor(x => x.TipoTransporte)
            .NotNull().WithMessage("Não pode ser nulo")
            .NotEmpty().WithMessage("Não pode ser vazio")
            .IsInEnum().WithMessage("Tipo de transporte incorreto");


            RuleFor(dt => new { dt.DataIda, dt.DataVolta })
            .Must(x => ValidaData(x.DataIda, x.DataVolta))
            .WithMessage("Data de partida deve ser inferior a data de retorno")
            .Must(x => DataVoltaInferiorUmAno(x.DataIda, x.DataVolta))
            .WithMessage("Data de retorno deve ser inferior a um ano");

            RuleFor(dt => new { dt.DataIda, dt.DataVolta })
            .Must(x => ValidaFormatoData(x.DataIda) && ValidaFormatoData(x.DataVolta))
            .WithMessage("Informe a data no formato correto");


        }
        private bool ValidaMatriculas(long matriculaSolicitante, long matriculaAprovador)
         => matriculaSolicitante != matriculaAprovador;

        private bool ValidaMatriculaAprovador(long matriculaAprovador)
        => matriculaAprovador.ToString() != _matriculaSistemica;

        private bool ValidaData(DateTime dataIda, DateTime dataVolta)
        => dataIda < dataVolta;

        private bool DataVoltaInferiorUmAno(DateTime dataIda, DateTime dataVolta)
          => (dataVolta - dataIda).TotalDays <= 365;

        private bool ValidaFormatoData(DateTime dataViagem)
        => dataViagem is DateTime data;
    }
}
