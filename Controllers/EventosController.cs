using Connect.Auth.Commands;
using Connect.Auth.DTO;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EventosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("eventos")]
        public async Task<IActionResult> Mensagens(int setor)
        {
            var eventos = await _mediator.Send(new ObterEventoPorSetorQuery(setor));
            return Ok(eventos);
        }

        [HttpPost("addevento")]
        public async Task<IActionResult> addEvento([FromBody] EventoDTO evento)
        {
            var resultId = await _mediator.Send(new CriarEventoCommand(evento));
            return Ok(resultId);
        }
    }

}
