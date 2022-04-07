using API.Contexto;
using API.Interface;
using API.Models;
using API.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace API.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        private ITokenService _service;
        public UsuarioRepositorio(AcademiaContext context, ITokenService service, IHttpContextAccessor accessor) : base(context, accessor)
        {
            _service = service;
        }

        public async Task<Usuario> ObterUsuarioDiscord(Usuario usuario)
        {
            var usuarioDiscord = await ObterOnde(x => x.Email == usuario.Email);
            if (usuarioDiscord == null)
            {
                usuarioDiscord = await Adicionar(usuario);
            }

            usuarioDiscord.Token = _service.GenerateToken(usuarioDiscord);
            return usuarioDiscord;

        }
    }
}
