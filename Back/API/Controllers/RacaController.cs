using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(Roles = "ADM")]
    public class RacaController : ControllerBase
    {
        private readonly IRacaRepositorio _repository;
        public RacaController(IRacaRepositorio repository)
        {
            _repository = repository;
        }
        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<Raca>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        [HttpGet("ObterPorId/{id:long}")]
        public async Task<Raca> ObterPorId(long id)
        {
            return await _repository.ObterPorId(id);
        }

        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Raca obj)
        {
            return Ok(await _repository.Adicionar(obj));
        }

        [HttpPost("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] Raca obj)
        {
            return Ok(await _repository.Atualizar(obj));
        }

        [HttpPost("Desabilitar")]
        public async Task<ActionResult> Desabilitar([FromBody] Raca obj)
        {
            return Ok(await _repository.Desabilitar(obj));
        }
        [HttpPost("Habilitar")]
        public async Task<ActionResult> Habilitar([FromBody] Raca obj)
        {
            return Ok(await _repository.Habilitar(obj));
        }
        [HttpPost("Deletar")]
        public async Task<ActionResult> Deletar([FromBody] Raca obj)
        {
            return Ok(await _repository.Deletar(obj));
        }
    }
}
