using GerenciadorDeViagemApi.Core.Repositories;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.TravelCancelCommand
{
    public class CancelTravelCommandHandler : IRequestHandler<CancelTravelCommand, bool>
    {
        private readonly ITravelRepository _travelRepository = default!;

        public CancelTravelCommandHandler(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public async Task<bool> Handle(CancelTravelCommand request, CancellationToken cancellationToken)
        {
            var cancel = await _travelRepository.CancelTravel(request.Id);

            return cancel;
        }

    }
}
