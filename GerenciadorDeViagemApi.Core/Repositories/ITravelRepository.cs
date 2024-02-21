using GerenciadorDeViagem.Model;
using GerenciadorDeViagemApi.Core.DTOs;


namespace GerenciadorDeViagemApi.Core.Repositories
{
    public interface ITravelRepository
    {
        Task<string> ScheduleTrip(Viagem viagem);

        Task<(IEnumerable<TravelDTO> Viagens, string mensagemDeErro)> GetTravelsAsync(int matricula);

        Task<(IEnumerable<TravelDTO> Viagens, string mensagemErro)> GetTravelsIdAsync(int id);

        Task<bool> CancelTravel(int id);

        Task<bool> ApproveTravel(int id);
    }
}
