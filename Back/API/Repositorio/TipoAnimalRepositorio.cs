using API.Contexto;
using API.Interface;
using API.Models;

namespace API.Repositorio
{
    public class TipoAnimalRepositorio : BaseRepositorio<TipoAnimal>, ITipoAnimalRepositorio
    {
        public TipoAnimalRepositorio(AcademiaContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {
        }
    }
}
