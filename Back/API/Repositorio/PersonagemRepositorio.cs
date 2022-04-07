using API.Contexto;
using API.Interface;
using API.Models;

namespace API.Repositorio
{
    public class PersonagemRepositorio : BaseRepositorio<Personagem>, IPersonagemRepositorio
    {
        public PersonagemRepositorio(AcademiaContext context, IHttpContextAccessor accessor) : base(context, accessor)
        {

        }
    }
}
