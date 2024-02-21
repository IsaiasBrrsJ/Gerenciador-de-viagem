using GerenciadorDeViagem.Model.Enum;

namespace GerenciadorDeViagemApi.Core.DTOs
{
    public class TravelDTO
    {
        public TravelDTO(long matricula, string email, string nomeCompleto, string destino, DateTime dataIda, DateTime dataVolta, TipoTransporte tipoTransporte, StatusViagem statusViagem)
        {
            Matricula = matricula;
            Email = email;
            NomeCompleto = nomeCompleto;
            Destino = destino;
            DataIda = dataIda;
            DataVolta = dataVolta;
            TipoTransporte = tipoTransporte;
            StatusViagem = statusViagem;
        }

        public long Matricula { get; private set; }
        public string Email { get; private set; } = default!;
        public string NomeCompleto { get; private set; } = String.Empty;
        public string Destino { get; private set; } = String.Empty;
        public DateTime DataIda { get; private set; }
        public DateTime DataVolta { get; private set; }
        public TipoTransporte TipoTransporte { get; private set; }
        public StatusViagem StatusViagem { get; private set; }
    }
}
