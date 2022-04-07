using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Base
    {
        public long Id { get; set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizado { get; set; }
        public DateTime? DataInativado { get; set; }
        public DateTime? DataReativado { get; set; }
        public long? UsuarioIdCadastro { get; set; }
        public long? UsuarioIdAtualizado { get; set; }
        public long? UsuarioIdInativado { get; set; }
        public long? UsuarioIdReativado { get; set; }
        public bool Status { get; set; }
    }
}
