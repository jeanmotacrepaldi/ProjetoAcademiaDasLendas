using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(Roles = "ADM")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _repository;
        public UsuarioController(IUsuarioRepositorio repository)
        {
            _repository = repository;
        }
        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        [HttpGet("ObterPorId/{id:long}")]
        public async Task<Usuario> ObterPorId(long id)
        {
            return await _repository.ObterPorId(id);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Usuario obj)
        {
            return Ok(await _repository.Adicionar(obj));
        }

        [HttpPost("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] Usuario obj)
        {
            return Ok(await _repository.Atualizar(obj));
        }

        [HttpPost("Desabilitar")]
        public async Task<ActionResult> Desabilitar([FromBody] Usuario obj)
        {
            return Ok(await _repository.Desabilitar(obj));
        }
        [HttpPost("Habilitar")]
        public async Task<ActionResult> Habilitar([FromBody] Usuario obj)
        {
            return Ok(await _repository.Habilitar(obj));
        }
        [HttpPost("Deletar")]
        public async Task<ActionResult> Deletar([FromBody] Usuario obj)
        {
            return Ok(await _repository.Deletar(obj));
        }
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] Usuario obj)
        {
            var usuario = await _repository.ObterUsuarioDiscord(obj);
            return Ok(usuario);
        }
    }
}
