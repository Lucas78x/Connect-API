using AutoMapper;
using Connect.Auth.Commands;
using Connect.Auth.DTO;
using Connect.Auth.Models;
using Connect.Auth.Queries;
using Connect.Auth.Query.Connect.Auth.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FolhaPontoController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FolhaPontoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

       

        [HttpGet("obterfolhas")]
        public async Task<IActionResult> ObterFolhas()
        {
            var folhas = await _mediator.Send(new ObterFolhaPontoQuery());

            if (folhas != null)
            {
                return Ok(folhas);
            }
            else
            {
                return Ok(new List<FeriasModel>());
            }
        }

        [HttpGet("folhas")]
        public async Task<IActionResult> Folhas(Guid OwnerId)
        {
            var folhas = await _mediator.Send(new ObterFolhaPontoQuery(OwnerId));

            if (folhas != null)
            {
                return Ok(folhas);
            }
            else
            {
                return Ok(new List<FeriasModel>());
            }
        }

        [HttpPost("addfolha")]
        public async Task<IActionResult> AddFolha(FolhaPontoModel folhaModel)
        {

            var result = await _mediator.Send(new CriarFolhaPontoCommand(folhaModel));

            if (result != null)
            {
                return Ok(result.Value);
            }

            return BadRequest();
        }
    }

}
