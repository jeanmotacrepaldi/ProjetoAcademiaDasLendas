using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(Roles = "ADM")]
    public class CasaController : ControllerBase
    {
        private readonly ICasaRepositorio _repository;

        public CasaController(ICasaRepositorio repository)
        {
            _repository = repository;
        }
        [HttpGet("ObterTodos")]
        
        public async Task<IEnumerable<Casa>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }
        [HttpGet("ObterPorId/{id:long}")]
        public async Task<Casa> ObterPorId(long id)
        {
            return await _repository.ObterPorId(id);
        }
        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Casa obj)
        {
            return Ok(await _repository.Adicionar(obj));
        }
        [HttpPost("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] Casa obj)
        {
            return Ok(await _repository.Atualizar(obj));
        }
        [HttpPost("Desabilitar")]
        public async Task<ActionResult> Desabilitar([FromBody] Casa obj)
        {
            return Ok(await _repository.Desabilitar(obj));
        }
        [HttpPost("Habilitar")]
        public async Task<ActionResult> Habilitar([FromBody] Casa obj)
        {
            return Ok(await _repository.Habilitar(obj));
        }
        [HttpPost("Deletar")]
        public async Task<ActionResult> Deletar([FromBody] Casa obj)
        {
            return Ok(await _repository.Deletar(obj));
        }

    }
}
