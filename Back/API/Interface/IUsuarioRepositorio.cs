using API.Models;

namespace API.Interface
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Task<Usuario> ObterUsuarioDiscord(Usuario usuario);
    }
}
