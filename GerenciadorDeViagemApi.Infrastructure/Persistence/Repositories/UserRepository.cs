using Dapper;
using GerenciadorDeViagem.Model;
using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.EmailTemplates;
using GerenciadorDeViagemApi.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GerenciadorDeViagemApi.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GerenciadorDeViagemDbContext _dbContext = default!;

        private IConfiguration _Configuration { get; init; }
        public UserRepository(GerenciadorDeViagemDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _Configuration = configuration;
        }

        public async Task<int> AddUserAsync(Usuario usuario)
        {
            
            await  _dbContext.AddAsync(usuario);

             await _dbContext.SaveChangesAsync();

            return usuario.Id;
        }

        public async Task<UserDTO> GetByIdUserAsync(long matricula)
        {
            var connectionString = _Configuration.GetConnectionString("sqlServer");
            string query = @"SELECT Matricula, Email, NomeCompleto FROM dbo.usuario 
                                         WHERE Matricula = @Matricula";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Matricula", matricula);


                var resultQuery = await sqlConnection.QuerySingleOrDefaultAsync<UserDTO>(query, parameters);

                sqlConnection.Close();


                return resultQuery!;

            }
       
        }

        public async Task<Usuario> LoginUserAsync(long matricula, string hashPassword)
        {
            var user = await _dbContext.Usuario.SingleOrDefaultAsync(x => x.Matricula == matricula && x.Senha == hashPassword);

            if (user is null)
                return null!;

            user.UpdateLastLoginUser();

            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();


            return user;
        }

        public async Task Delete(long matricula)
        {
            var matriculaUserSistemico = _Configuration["UsuarioSistemico:Matricula"];
            var connectionString = _Configuration.GetConnectionString("SqlServer");

            using(var sqlConnection = new SqlConnection(connectionString))
            {
                var query = @"DELETE FROM dbo.usuario 
                                         WHERE Matricula = @Matricula AND Matricula != @UserSistemico";

                var parameters = new DynamicParameters();
                parameters.Add("@Matricula", matricula);
                parameters.Add("@UserSistemico", matriculaUserSistemico);

                await sqlConnection.OpenAsync();

                await sqlConnection.ExecuteScalarAsync(query, parameters);


                await sqlConnection.CloseAsync();

            }
        }

        public async Task<EmailDTO> GetUserByEmail(string email)
        {
            var connectionString = _Configuration.GetConnectionString("sqlServer");
            string query = @"SELECT NomeCompleto, Email, TipoDeUsuario FROM dbo.usuario 
                                         WHERE Email = @Email";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var parameters = new DynamicParameters();
                parameters.Add("@Email", email);


                var resultQuery = await sqlConnection.QuerySingleOrDefaultAsync<EmailDTO>(query, parameters);
                resultQuery.EmailSubject = "Recuperação de Senha";
               
                sqlConnection.Close();

                return resultQuery!;
            }
        }

        public async Task<EmailDTO> UpdatePassword(long matricula, string oldPasswordHash, string hashPassword)
        {
            var user =await _dbContext.Usuario.SingleOrDefaultAsync(x => x.Matricula == matricula && x.Senha == oldPasswordHash);


            if (user is null)
                return null!;


            if (user.PrimeiroAcesso)
                user.RemoveFlagFirstLogin();

            var emailDTO = new EmailDTO(user.NomeCompleto, user.Email, user.TipoDeUsuario, "Aviso, Alteração de Senha", user.Matricula, String.Empty);

            user.ConvertPassToHash(hashPassword);

            _dbContext.Entry(user).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return emailDTO;
        }
    }
}
