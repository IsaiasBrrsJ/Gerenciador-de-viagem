using GerenciadorDeViagem.Model.Enum;
using GerenciadorDeViagemApi.Core.Entities;

namespace GerenciadorDeViagem.Model
{
    public class Viagem : EntityBase
    {
        public Viagem(string destino, DateTime dataIda, DateTime dataVolta, TipoTransporte tipoTransporte, long usuarioSolicitanteMatricula, long usuarioAprovadorMatricula)
        { 
            Destino = destino;
            DataIda = dataIda;
            DataVolta = dataVolta;
            TipoTransporte = tipoTransporte;
            DataDaSolicitacao = DateTime.Now;
            StatusViagem = StatusViagem.Agendada;
            UsuarioSolicitanteMatricula = usuarioSolicitanteMatricula;
            UsuarioAprovadorMatricula = usuarioAprovadorMatricula;

        }

        public bool ApproveTravel()
        {
            if (
                 (StatusViagem is StatusViagem.Pendente || StatusViagem is StatusViagem.Agendada) 
                  ||
                 (StatusViagem is StatusViagem.Cancelada && DataCancelamento!.Value.Hour < TimeSpan.FromHours(24).TotalHours)
                )
            {
                StatusViagem = StatusViagem.Aprovado;
                DataAprovacao = DateTime.Now;
                DataCancelamento = null;

                return true;
            }

            return false;
        }
       
        public bool CancelTravel()
        {
            if (
                (StatusViagem is StatusViagem.Pendente || StatusViagem is StatusViagem.Agendada)
                 ||
                (StatusViagem is StatusViagem.Aprovado && DataAprovacao!.Value.Hour < TimeSpan.FromHours(24).TotalHours)
               )
            {
                StatusViagem = StatusViagem.Cancelada;
                DataCancelamento = DateTime.Now;
                DataAprovacao = null;

                return true;
            }

            return false;
        }
     
        public string Destino { get; private set; } = String.Empty; 
        public DateTime DataIda { get; private set; }
        public DateTime DataVolta { get; private set; }
        public TipoTransporte TipoTransporte { get; private set; }
        public DateTime DataDaSolicitacao { get; private set; }
        public DateTime? DataAprovacao { get; private set; }
        public DateTime? DataCancelamento { get; private set; }
        public StatusViagem StatusViagem { get; private set; }
        public virtual Usuario UsuarioSolicitante { get; private set; }
        public long UsuarioSolicitanteMatricula { get; private set; }
        public virtual Usuario UsuarioAprovador { get; private set; }
        public long UsuarioAprovadorMatricula { get; private set; }
      
    }
}
