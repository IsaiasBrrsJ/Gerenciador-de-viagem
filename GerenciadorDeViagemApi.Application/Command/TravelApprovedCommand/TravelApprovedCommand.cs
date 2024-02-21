using MediatR;

namespace GerenciadorDeViagemApi.Application.Command.TravelApprovedCommand
{
    public class TravelApprovedCommand : IRequest<bool>
    {
        public TravelApprovedCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
