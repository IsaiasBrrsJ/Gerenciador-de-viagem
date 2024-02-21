using Dapper;
using GerenciadorDeViagem.Model;
using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Enums;
using GerenciadorDeViagemApi.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Repositories
{
    public class TravelRepositry : ITravelRepository
    {
        private readonly GerenciadorDeViagemDbContext _dbContext = default!;
        private readonly IConfiguration _configuration = default!;

        public TravelRepositry(GerenciadorDeViagemDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<bool> ApproveTravel(int id)
        {
            var travel = await _dbContext.Viagens.SingleOrDefaultAsync(x => x.Id == id);

            if (travel == null)
                return false;

            var travelIsApproved = travel.ApproveTravel();

            if (!travelIsApproved)
                return travelIsApproved;


           _dbContext.Entry(travel).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return travelIsApproved;
        }
        public async Task<bool> CancelTravel(int id)
        {
           
            var findTravel = await _dbContext.Viagens.SingleOrDefaultAsync(x => x.Id == id);

            if (findTravel == null)
                return false;

            var travelIsCancelled = findTravel.CancelTravel();

            if (!travelIsCancelled)
                return travelIsCancelled;


              _dbContext.Entry(findTravel).State = EntityState.Modified;

              await _dbContext.SaveChangesAsync();
            

            return travelIsCancelled;
        }

        public async Task<(IEnumerable<TravelDTO>? Viagens, string mensagemDeErro)> GetTravelsAsync(int matricula)
        {

            var connectionString = _configuration.GetConnectionString("sqlServer");

            var query = @"
              SELECT U.Matricula, U.Email, U.NomeCompleto, V.Destino, V.DataIda, V.DataVolta,V.TipoTransporte, V.StatusViagem  FROM Usuario U
              INNER JOIN Viagens V
              ON U.Matricula = @Matricula;
              ";

            var parameters = new DynamicParameters();
            parameters.Add("@Matricula", matricula);


            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    IEnumerable<TravelDTO> travel = await sqlConnection.QueryAsync<TravelDTO>(query, parameters);

                    return  (travel, String.Empty);
                }

            }
            catch (Exception ex)
            {
                return  (null, "ERRO Repository TravelRepositry Consulta Viagens Matricula, erro: "+ex.Message);
            }

        }

        public async Task<(IEnumerable<TravelDTO> Viagens, string mensagemErro)> GetTravelsIdAsync(int id)
        {
            var connectionString = _configuration.GetConnectionString("c");

            var query = @"
              SELECT U.Matricula, U.Email, U.NomeCompleto, V.Destino, V.DataIda, V.DataVolta,V.TipoTransporte, V.StatusViagem  FROM Usuario U
              INNER JOIN Viagens V
              ON U.Matricula = V.UsuarioSolicitanteMatricula
              WHERE V.Id = @Id;
              ";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);


            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();

                    IEnumerable<TravelDTO> travel = await sqlConnection.QueryAsync<TravelDTO>(query, parameters);

                    return (travel, String.Empty);
                }

            }
            catch (Exception ex)
            {
                return (null!, "ERRO Repository TravelRepositry Consulta Viagens Id, erro: " + ex.Message);
            }
        }

        public async Task<string> ScheduleTrip(Viagem viagem)
        {
            try
            {
                await _dbContext.Viagens.AddAsync(viagem);

                await _dbContext.SaveChangesAsync();

              return viagem.Id.ToString();
            }
            catch(DbUpdateException ex)
            {
              if (ex.InnerException is SqlException sqlException && sqlException.Number == (int)CodigoErroBanco.InnerException)
                 return "Error = {MatriculaAprovador não pode ser igual a Matricula do solicante, ou Sistemico }";

                return ex.InnerException!.ToString();
            }
            catch(Exception ex)
            {
                return ex.InnerException!.Message;
            }
        }
    }
}
