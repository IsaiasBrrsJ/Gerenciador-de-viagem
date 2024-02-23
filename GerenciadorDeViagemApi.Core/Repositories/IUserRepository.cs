using GerenciadorDeViagem.Model;
using GerenciadorDeViagemApi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeViagemApi.Core.Repositories
{
    public interface IUserRepository
    {
        Task<int> AddUserAsync(Usuario usuario);
        Task<UserDTO> GetByIdUserAsync(long matricula);
        Task<Usuario> LoginUserAsync(long matricula, string hashPassword);
        Task Delete(long matricula); 
        Task<EmailDTO> GetUserByEmail(string email);
        Task<EmailDTO> UpdatePassword(long matricula,string oldPasswordHash, string hashPassword);
    }
}
