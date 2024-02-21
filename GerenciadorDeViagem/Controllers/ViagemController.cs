using GerenciadorDeViagemApi.Application.Command.CreateTravelCommand;
using GerenciadorDeViagemApi.Application.Command.TravelApprovedCommand;
using GerenciadorDeViagemApi.Application.Command.TravelCancelCommand;
using GerenciadorDeViagemApi.Application.Querie.GetTravelId;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeViagem.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class ViagemController : ControllerBase
    {
        
        private readonly IMediator _mediator = default!;
        public ViagemController(IMediator mediator)
         =>  _mediator = mediator;
        

        [HttpGet("ConsultarViagem")]
        [Authorize(Roles = "Administrador, Usuario, LoginSistemico")]
        public async Task<IActionResult> ConsultaViagem(GetTravelQuery query)
        {

            var result = await _mediator.Send(query);

            if (!result.Viagens.Any())
                return NotFound();

            if (result.Viagens == null)
                return BadRequest(result.mensagemDeErro);


            return Ok(result.Viagens);

        }
        [HttpGet("BuscarViagemPorId/{id}")]
        [Authorize(Roles = "Administrador, LoginSistemico")]
        public async Task<IActionResult> ObterViagemPorId([FromRoute] int id)
        {
            var viagemQueryId = new GetTravelIdQuery(id);

            var result = await _mediator.Send(viagemQueryId);

            if (!result.viagens.Any())
                return NotFound();
            
            if(result.viagens == null)
                return BadRequest(result.mensagemErro);


            return Ok(result.viagens);
        }
        [HttpPost("CadastrarViagem")]
        [Authorize(Roles ="Administrador, Usuario")]
        public async Task<IActionResult> MarcarViagem(CreateTravelCommand command)
        {
         
            var viagem = await _mediator.Send(command);

            return Ok(viagem);
        }
        [HttpPatch("CancelaViagem/{id}")]
        [Authorize(Roles = "Administrador, Usuario")]
      
        public async Task<IActionResult> CancelaViagem([FromRoute] int id)
        {

            var commandCancel = new CancelTravelCommand(id);

           var result = await _mediator.Send(commandCancel);

            if (result is false)
                return BadRequest(new { Error = "Não foi possivel cancelar valide as regras de negocio" });


            return NoContent();
        }
 
        [HttpPatch("Aprovar/{id}")]
        [Authorize(Roles = "Administrador, LoginSistemico")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AprovarViagem([FromRoute] int id)
        {
            var travelApprovedCommand = new TravelApprovedCommand(id);

            var result = await _mediator.Send(travelApprovedCommand);

            if (result is false)
                return BadRequest(new {Error = "Não foi possivel cancelar valide as regras de negocio"});

            return NoContent();
        }
    }
}
