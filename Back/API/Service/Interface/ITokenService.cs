using API.Models;

namespace API.Service.Interface
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
