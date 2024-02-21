using GerenciadorDeViagem.Model.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeViagemApi.Application.Command.CreateTravelCommand
{
    public class CreateTravelCommand : IRequest<string>
    {
        public string Destino { get;  set; } = String.Empty;
        public DateTime DataIda { get;  set; }
        public DateTime DataVolta { get;  set; }
        public TipoTransporte TipoTransporte { get;  set; }
        public long MatriculaAprovador { get ; set; }    
        public long MatriculaSolicitante { get; set; }
    }
}
