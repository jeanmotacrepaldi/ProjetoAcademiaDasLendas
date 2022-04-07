using API.Contexto;
using API.Interface;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorio
{
    public class CasaRepositorio : BaseRepositorio<Casa>, ICasaRepositorio
    {
        public CasaRepositorio(AcademiaContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {

        }
    }
}
