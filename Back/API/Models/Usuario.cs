using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Usuario : Base
    {
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public int Discriminator { get; set; }
        public string DiscordId { get; set; }
        public string PerfilAcesso { get; set; }

        [NotMapped]
        public string Token { get; set; }
    }
}
