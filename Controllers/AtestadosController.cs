using AutoMapper;
using Connect.Auth.Commands;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtestadosController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AtestadosController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("atestados")]
        public async Task<IActionResult> Atestados(Guid OwnerId)
        {
            var eventos = await _mediator.Send(new ObterAtestadosQuery(OwnerId));

            if (eventos != null)
            {
                return Ok(eventos);
            }
            else
            {
                return Ok();
            }
        }

        [HttpPost("addatestado")]
        public async Task<IActionResult> addAtestado(AtestadoModel atestadoModel)
        {
            var atestadoDto = _mapper.Map<AtestadoDTO>(atestadoModel);

            var result = await _mediator.Send(new CriarAtestadoCommand(atestadoDto));
            if (result != null)
            {
                return Ok();
            }

            return BadRequest();
        }
    }

}
