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
    public class FeriasController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FeriasController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        //[HttpGet("ferias")]
        //public async Task<IActionResult> Atestados(Guid OwnerId)
        //{
        //    var eventos = await _mediator.Send(new ObterAtestadosQuery(OwnerId));

        //    if (eventos != null)
        //    {
        //        return Ok(eventos);
        //    }
        //    else
        //    {
        //        return Ok();
        //    }
        //}

        [HttpGet("ferias")]
        public async Task<IActionResult> Ferias()
        {
            var ferias = await _mediator.Send(new ObterFeriasQuery());

            if (ferias != null)
            {
                return Ok(ferias);
            }
            else
            {
                return Ok(new List<FeriasModel>());
            }
        }

        [HttpPost("addferias")]
        public async Task<IActionResult> AddFerias(FeriasModel feriasModel)
        {

            var result = await _mediator.Send(new CriarFeriasCommand(feriasModel));

            if (result != null)
            {
                return Ok(result.Value);
            }

            return BadRequest();
        }
    }

}
