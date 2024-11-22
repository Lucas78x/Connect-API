
using Connect.Auth.Commands;
using Connect.Auth.DTO;
using Connect.Auth.Enums;
using Connect.Auth.Models;
using Connect.Auth.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Connect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<int>> Register([FromBody]RegisterModel register)
        {
            
            var func = new FuncionarioDTO(register.Nome, register.Sobrenome, register.CPF, register.RG,register.Telefone, (TipoGeneroEnum)register.Genero, register.Email, register.DataNascimento, register.Cargo, (TipoPermissaoEnum)register.Permissao);
            var login = new LoginDTO(register.Email, register.PasswordHash, func);

            var funcModel = await _mediator.Send(new RegistrarFuncionarioCommand(login));
            if (funcModel != null)
            {
                return Ok(funcModel);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login([FromBody]LoginModel login)
        {
            
            var result = await _mediator.Send(new ConsultarUsuarioQuery(login.Email,login.PasswordHash));
            if (result == null)
            {
                return Unauthorized();
            }

            login.Id = result.Id;
            login.Genero = result.Funcionario.Genero.GetHashCode();

            return Ok(login);
        }

        [HttpGet("funcionario")]
        public async Task<ActionResult<string>> Funcionario(int Id )
        {

            var result = await _mediator.Send(new ConsultarUsuarioByIdQuery(Id));
            if (result == null)
            {
                return Unauthorized();
            }

            
            return Ok(result);
        }

        [HttpGet("FuncionarioById")]
        public async Task<ActionResult<string>> FuncionarioById(Guid Id)
        {

            var result = await _mediator.Send(new ConsultarFuncionarioByIdQuery(Id));
            if (result == null)
            {
                return Unauthorized();
            }


            return Ok(result);
        }

        [HttpGet("funcionarios")]
        public async Task<ActionResult<string>> Funcionarios()
        {

            var result = await _mediator.Send(new BuscarFuncionariosQuery());
            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }
        [HttpGet("listaRequisicoes")]
        public async Task<ActionResult<string>> ListaRequisicoes()
        {

            var result = await _mediator.Send(new BuscarRequisicoesQuery());

            if (result == null)
            {
                return Unauthorized();
            }


            return Ok(result);
        }

        [HttpPost("requisicoes")]
        public async Task<ActionResult<string>> Requisicioes(FuncionarioDTO funcionario)
        {

            var result = await _mediator.Send(new ConsultarRequisicoesByIdQuery(funcionario));
           
            return Ok(result);
        }

        [HttpGet("requisicao")]
        public async Task<ActionResult<string>> Requisicao(Guid id)
        {

            var result = await _mediator.Send(new ConsultarRequisicaoByIdQuery(id));

            return Ok(result);
        }

         [HttpPost("atualizarRequisicao")]
        public async Task<ActionResult<string>> AtualizarRequisicao([FromBody] RequisicaoModel requisicao)
        {

            var result = await _mediator.Send(new AtualizarRequisicaoByIdCommand(requisicao));

            return Ok(result);
        }

    }
}
