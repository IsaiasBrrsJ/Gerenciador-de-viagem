using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.TravelCancelCommand
{
    public class CancelTravelCommand : IRequest<bool>
    {
        public CancelTravelCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
