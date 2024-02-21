using GerenciadorDeViagemApi.Core.DTOs;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Querie.GetTravelId
{
    public class GetTravelIdQuery : IRequest<(IEnumerable<TravelDTO>? viagens, string mensagemErro)>
    {
        public  int Id { get; init ; }

        public GetTravelIdQuery(int id)
        {
            Id = id;
        }
    }
}
