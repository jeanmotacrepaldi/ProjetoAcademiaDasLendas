using API.Models;
using API.Service.Interface;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Service
{
    public class TokenService : ITokenService
    {
        public string GenerateToken(Usuario usuario)
        {
            var secret = Encoding.ASCII.GetBytes(Settings.Instance.Secret);

            var tokenData = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddHours(12),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, $"{usuario.Username}#{usuario.Discriminator}"),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.PerfilAcesso),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),

                }),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenData);
            return tokenHandler.WriteToken(token);
        }
    }
}
