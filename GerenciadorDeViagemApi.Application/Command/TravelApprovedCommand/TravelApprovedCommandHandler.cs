using GerenciadorDeViagemApi.Core.Repositories;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.TravelApprovedCommand
{
    public class TravelApprovedCommandHandler : IRequestHandler<TravelApprovedCommand, bool>
    {
        private readonly ITravelRepository _travelRepository = default!;
        public TravelApprovedCommandHandler(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }
        public async Task<bool> Handle(TravelApprovedCommand request, CancellationToken cancellationToken)
        {
           var approved = await  _travelRepository.ApproveTravel(request.Id);

            return approved;
        }
    }
}
