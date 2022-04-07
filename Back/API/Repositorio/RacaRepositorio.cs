using API.Contexto;
using API.Interface;
using API.Models;

namespace API.Repositorio
{
    public class RacaRepositorio : BaseRepositorio<Raca>, IRacaRepositorio
    {
        public RacaRepositorio(AcademiaContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {
        }
    }
}
