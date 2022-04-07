using API.Contexto;
using API.Interface;
using API.Models;

namespace API.Repositorio
{
    public class CargoRepositorio : BaseRepositorio<Cargo>, ICargoRepositorio
    {
        public CargoRepositorio(AcademiaContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {
        }
    }
}
