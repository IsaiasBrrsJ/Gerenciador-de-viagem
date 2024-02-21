using GerenciadorDeViagemApi.Core.DTOs;
using GerenciadorDeViagemApi.Core.Repositories;
using MediatR;

namespace GerenciadorDeViagemApi.Application.Querie.GetUserMatriculaQuery
{
    public class GetUserMatriculaQueryHandler : IRequestHandler<GetUserMatriculaQuery, UserDTO>
    {
        public IUsuarioRepository _userRepository { get;  init; } = default!;
        public GetUserMatriculaQueryHandler(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserDTO> Handle(GetUserMatriculaQuery request, CancellationToken cancellationToken)
        {
            var getUser = _userRepository.GetByIdUserAsync(request.Matricula);

            return getUser;
        }
    }
}
