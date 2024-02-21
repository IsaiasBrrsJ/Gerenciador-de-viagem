using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Repositories;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Querie.GetTravelId
{
    public class GetTravelQueryHandler : IRequestHandler<GetTravelQuery, (IEnumerable<TravelDTO>? viagens, string mensagemDeErro)>
    {

        private readonly ITravelRepository _travelRepository = default!;

        public GetTravelQueryHandler(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public async Task<(IEnumerable<TravelDTO>? viagens, string mensagemDeErro)> Handle(GetTravelQuery request, CancellationToken cancellationToken)
        {
            
            var result = await _travelRepository.GetTravelsAsync(request.Matricula);


            return (result.Viagens, result.mensagemDeErro);  
        }

        
    }
}
