using Connect.Auth.Commands;
using Connect.Auth.DTO;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComunicadosController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComunicadosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("comunicados")]
        public async Task<IActionResult> Comunicados()
        {
            var comunicados = await _mediator.Send(new ObterComunicadosQuery());
            return Ok(comunicados);
        }

        [HttpPost("addcomunicado")]
        public async Task<IActionResult> addComunicado([FromBody] ComunicadosDTO comunicados)
        {
            var resultId = await _mediator.Send(new CriarComunicadosCommand(comunicados));
            return Ok(resultId);
        }
    }

}
