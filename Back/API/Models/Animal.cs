namespace API.Models
{
    public class Animal : Base
    {
        public string Nome { get; set; }
        public long TipoAnimalId { get; set; }
        public long GeneroId { get; set; }
        public TipoAnimal TipoAnimal { get; set; }
        public Genero Genero { get; set; }
    }
}
