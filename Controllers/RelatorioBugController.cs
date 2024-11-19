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
    public class RelatoBugController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RelatoBugController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }



        [HttpGet("relatoriosBug")]
        public async Task<IActionResult> ObterBugs()
        {
            var bugs = await _mediator.Send(new ObterRelatoBugQuery());

            if (bugs != null)
            {
                return Ok(bugs);
            }
            else
            {
                return Ok(new List<FeriasModel>());
            }
        }

       

        [HttpPost("addRelatorioBug")]
        public async Task<IActionResult> AddBug(RelatoBugModel bugModel)
        {

            var result = await _mediator.Send(new CriarRelatoBugCommand(bugModel));

            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }

}
