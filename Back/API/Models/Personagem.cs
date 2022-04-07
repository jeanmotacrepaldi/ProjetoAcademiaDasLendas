namespace API.Models
{
    public class Personagem : Base
    {
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Personalidade { get; set; }
        public string Historia { get; set; }
        public string Aparencia { get; set; }
        public long GeneroId { get; set; }
        public long RacaId { get; set; }
        public long CasaId { get; set; }
        public long AnimalId { get; set; }
        public long CargoId { get; set; }

        public Genero Genero { get; set; }
        public Raca Raca{ get; set; }
        public Casa Casa{ get; set; }
        public Animal Animal { get; set; }
        public List<Cargo> Cargos { get; set; }
    }
}
