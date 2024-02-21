using GerenciadorDeViagemApi.Application.Command.CreateUserCommand;
using GerenciadorDeViagemApi.Application.Command.DeleteUserCommand;
using GerenciadorDeViagemApi.Application.Querie.GetUserMatriculaQuery;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeViagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrador, LoginSistemico")]
    public class AdministradorController : ControllerBase
    {
       
        private readonly IMediator _mediator;
        public AdministradorController( IMediator mediator)
        =>  _mediator = mediator;
        
        
        [HttpPost("CadastroUsuario")]
        public async Task<IActionResult> CadastroUsuario(CreateUserCommand command)
        {
            var result = await  _mediator.Send(command);

            return Created("https://localhost.com/", result);
        }

        [HttpGet("ConsultarUsuario/{matricula}")]
        public async Task<IActionResult> ConsultarUsuario([FromRoute] long matricula)
        {
            var query =  new GetUserMatriculaQuery(matricula);

            var queryResult = await _mediator.Send(query);  

            if (queryResult is null)
                return NotFound();

            

            return Ok(queryResult);
        }

        [HttpDelete("DeletaUsuario/{matricula}")]
        public async Task<IActionResult> DeletaUsuario([FromRoute] long matricula)
        {
            var command = new DeleteUserCommand(matricula);

           await _mediator.Send(command);

            return NoContent();
        }


        [HttpPut("AlterarUsuario/{matricula}")]
        public async Task<IActionResult> AtualizaUsuario()
        {
             return Ok();
        }

    }
}
