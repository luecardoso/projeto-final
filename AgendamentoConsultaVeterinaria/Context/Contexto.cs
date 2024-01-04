using AgendamentoConsultaVeterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendamentoConsultaVeterinaria.Context
{
    public class Contexto : DbContext
    {
        public DbSet<AnimalModel> Animal { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ConsultaModel> Consulta { get; set; }
        public DbSet<EnderecoModel> Endereco { get; set; }
        public DbSet<MedicoModel> Medico { get; set; }
        public DbSet<UnidadeModel> Unidade { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/relationships
            //https://learn.microsoft.com/pt-br/ef/core/saving/cascade-delete
            modelBuilder.Entity<ClienteModel>()
                .HasOne(c => c.Endereco)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<UnidadeModel>()
                .HasOne(u => u.Endereco)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AnimalModel>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Animais)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicoModel>()
                .HasOne(m => m.Unidade)
                .WithOne()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Medico)
                .WithMany(m => m.Consultas)
                .HasForeignKey(c => c.MedicoId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Animal)
                .WithMany(a => a.Consultas)
                .HasForeignKey(c => c.AnimalId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<ConsultaModel>()
                .HasOne(c => c.Unidade)
                .WithMany(a => a.Consultas)
                .HasForeignKey(c => c.UnidadeId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<HoraAtivaModel>()
           .HasOne(h => h.DataHora)
           .WithMany(d => d.HorasAtivas)
           .HasForeignKey(h => h.DataHoraId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
