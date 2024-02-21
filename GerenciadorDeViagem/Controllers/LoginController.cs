using GerenciadorDeViagemApi.Application.Command.LoginCommand;
using GerenciadorDeViagemApi.Application.Command.RecoverPasswordCommand;
using GerenciadorDeViagemApi.Application.Command.UpdatePasswordCommand;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeViagem.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator = default!;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            
            return Ok(new { token = result.token, primeiroAcesso = result.primeiroAcesso});
        }

        [HttpPatch("AtualizarSenha")]
        public async Task<IActionResult> AlterarSenha([FromBody] UpdatePasswordCommand command)
        {
            await _mediator.Send(command);

            return Accepted();
        }

        [HttpPost("RecuperarSenha")]
        public async Task<IActionResult> RecuperarSenha([FromBody] RecoverPasswordCommand command)
        {
            await _mediator.Send(command);

            return Accepted();
        }
    }
}
