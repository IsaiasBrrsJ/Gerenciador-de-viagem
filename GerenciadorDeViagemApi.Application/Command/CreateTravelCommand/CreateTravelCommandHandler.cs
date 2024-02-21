using GerenciadorDeViagem.Model;
using GerenciadorDeViagemApi.Core.Repositories;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.CreateTravelCommand
{
    public class CreateTravelCommandHandler : IRequestHandler<CreateTravelCommand, string>
    {
        private readonly ITravelRepository _travelRepository = default!;

        public CreateTravelCommandHandler(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public async Task<string> Handle(CreateTravelCommand request, CancellationToken cancellationToken)
        {
            var travel = new Viagem(request.Destino, request.DataIda, request.DataVolta, request.TipoTransporte, request.MatriculaSolicitante, request.MatriculaAprovador);

            var result =   await _travelRepository.ScheduleTrip(travel);
        
            return result;
        }
    }
}
