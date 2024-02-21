using GerenciadorDeViagemApi.Core.DTOs;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Querie.GetTravelId
{
    public class GetTravelQuery : IRequest<(IEnumerable<TravelDTO>? Viagens, string mensagemDeErro)>
    {
         public int Matricula { get; set; }
    }
}
