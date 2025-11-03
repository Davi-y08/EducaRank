using EducaRank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EducaRank.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Sala> Salas { get; set; }   
        public DbSet<AlunoCredencial> AlunosCredenciais { get; set; }
        public DbSet<ProfessorCredencial> ProfessoresCredenciais { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>()
            .HasOne(p => p.Sala)
            .WithMany(p => p.Alunos)
            .HasForeignKey(a => a.SalaId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Professor>()
            .HasMany(p => p.Salas)
            .WithMany();
        }

    }
}
