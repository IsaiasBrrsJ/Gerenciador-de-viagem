using GerenciadorDeViagemApi.Core.DTOs;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Querie.GetUserMatriculaQuery
{
    public class GetUserMatriculaQuery : IRequest<UserDTO>
    {
        public GetUserMatriculaQuery(long matricula)
        {
            Matricula = matricula;
        }

        public long Matricula { get; set; }
    }
}
