using API.Mapping;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Contexto
{
    public class AcademiaContext : DbContext
    {
        public AcademiaContext() : base()
        {
        }

        public AcademiaContext(DbContextOptions<AcademiaContext> options) : base(options)
        {
        }

        public virtual DbSet<Animal> Animal { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<Casa> Casa{ get; set; }
        public virtual DbSet<Raca> Raca { get; set; }
        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Personagem> Personagem { get; set; }
        public virtual DbSet<TipoAnimal> TipoAnimal { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GeneroMap());
            modelBuilder.ApplyConfiguration(new AnimalMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new CasaMap());
            modelBuilder.ApplyConfiguration(new PersonagemMap());
            modelBuilder.ApplyConfiguration(new TipoAnimalMap());
            modelBuilder.ApplyConfiguration(new RacaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());

        base.OnModelCreating(modelBuilder);
        }

    }
}
