using Connect.Auth.Commands;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MensagemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MensagemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("mensagens")]
        public async Task<IActionResult> Mensagens()
        {

            var mensagem = await _mediator.Send(new ObterTodasMensagensQuery());
            return Ok(mensagem);
        }

        [HttpGet("mensagem/{mensagemId}")]
        public async Task<IActionResult> Mensagem(string mensagemId)
        {
            if (!Guid.TryParse(mensagemId, out var mensagemGuid))
            {
                return BadRequest("Invalid message ID.");
            }

            var mensagem = await _mediator.Send(new ObterMensagemPorIdQuery(mensagemGuid));

            if (mensagem == null)
            {
                return NotFound();
            }

            return Ok(mensagem);
        }
        [HttpPost("criar")]
        public async Task<IActionResult> Criar([FromBody] CriarMensagemCommand command)
        {
            var mensagemId = await _mediator.Send(command);
            return Ok(mensagemId);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarMensagemCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPut("marcarComoLida")]
        public async Task<IActionResult> MarcarComoLida([FromBody] MarcarMensagemComoLidaCommand command)
        {
            var task = Task.Run(async () =>
            {
                await _mediator.Send(command);
            });

            await task;

            return NoContent();
        }

        [HttpDelete("deletar/{mensagemId}")]
        public async Task<IActionResult> Deletar(Guid mensagemId)
        {
            await _mediator.Send(new DeletarMensagemCommand(mensagemId));
            return NoContent();
        }
    }

}
