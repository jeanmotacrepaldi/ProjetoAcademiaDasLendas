using API.Contexto;
using API.Interface;
using API.Models;

namespace API.Repositorio
{
    public class GeneroRepositorio : BaseRepositorio<Genero>, IGeneroRepositorio
    {
        public GeneroRepositorio(AcademiaContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {
        }
    }
}
