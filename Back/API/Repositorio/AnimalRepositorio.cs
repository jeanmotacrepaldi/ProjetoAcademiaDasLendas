using API.Contexto;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorio
{
    public class AnimalRepositorio : BaseRepositorio<Animal>, IAnimalRepositorio
    {
        public AnimalRepositorio(AcademiaContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {
        }
        public override async Task<IEnumerable<Animal>> ObterTodos()
        {
            return await _context.Animal
                .Include(t => t.TipoAnimal)
                .Include(t => t.Genero)
                .ToListAsync();
        }
        public override async Task<Animal> ObterPorId(long id)
        {
            return await _context.Animal
                .Include(t => t.TipoAnimal)
                .Include(t => t.Genero)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
