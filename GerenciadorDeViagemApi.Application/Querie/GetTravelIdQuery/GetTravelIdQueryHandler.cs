using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Repositories;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Querie.GetTravelId
{
    public class GetTravelIdQueryHandler : IRequestHandler<GetTravelIdQuery, (IEnumerable<TravelDTO>? viagens, string mensagemErro)>
    {
        private readonly ITravelRepository _travelRepository = default!;

        public GetTravelIdQueryHandler(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public async Task<(IEnumerable<TravelDTO>? viagens, string mensagemErro)> Handle(GetTravelIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _travelRepository.GetTravelsIdAsync(request.Id);

            return (result.Viagens, result.mensagemErro);
        }
    }
}
