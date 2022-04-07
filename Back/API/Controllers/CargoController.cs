using API.Interface;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(Roles = "ADM")]
    public class CargoController : ControllerBase
    {
        private readonly ICargoRepositorio _repository;

        public CargoController(ICargoRepositorio repository)
        {
            _repository = repository;
        }
        [HttpGet("ObterTodos")]
        public async Task<IEnumerable<Cargo>> ObterTodos()
        {
            return await _repository.ObterTodos();
        }

        [HttpGet("ObterPorId/{id:long}")]
        public async Task<Cargo> ObterPorId(long id)
        {
            return await _repository.ObterPorId(id);
        }
        [HttpPost("Adicionar")]
        public async Task<ActionResult> Adicionar([FromBody] Cargo obj)
        {
            return Ok(await _repository.Adicionar(obj));
        }
        [HttpPost("Atualizar")]
        public async Task<ActionResult> Atualizar([FromBody] Cargo obj)
        {
            return Ok(await _repository.Atualizar(obj));
        }

        [HttpPost("Desabilitar")]
        public async Task<ActionResult> Desabilitar([FromBody] Cargo obj)
        {
            return Ok(await _repository.Desabilitar(obj));
        }

        [HttpPost("Habilitar")]
        public async Task<ActionResult> Habilitar([FromBody] Cargo obj)
        {
            return Ok(await _repository.Habilitar(obj));
        }
        [HttpPost("Deletar")]
        public async Task<ActionResult> Deletar([FromBody] Cargo obj)
        {
            return Ok(await _repository.Deletar(obj));
        }
    }

}
