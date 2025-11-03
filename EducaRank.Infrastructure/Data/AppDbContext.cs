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

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(a => a.Credencial)
                .WithOne()
                .HasForeignKey<AlunoCredencial>(c => c.AlunoId)
                .IsRequired();

                entity.HasOne(a => a.Sala)
                .WithMany(s => s.Alunos)
                .HasForeignKey(a => a.SalaId);
            });

            modelBuilder.Entity<AlunoCredencial>(entity =>
            {
                entity.HasKey(c => c.AlunoId);
                entity.Property(c => c.SenhaHash).IsRequired();
                entity.Property(c => c.Salt).IsRequired();
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasOne(p => p.Credencial)
                      .WithOne()
                      .HasForeignKey<ProfessorCredencial>(c => c.ProfessorId)
                      .IsRequired();
            });

            modelBuilder.Entity<ProfessorCredencial>(entity =>
            {
                entity.HasKey(c => c.ProfessorId);
                entity.Property(c => c.SenhaHash).IsRequired();
                entity.Property(c => c.Salt).IsRequired();
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.NomeSala).HasMaxLength(50);
                entity.HasMany(s => s.Alunos)
                      .WithOne(a => a.Sala)
                      .HasForeignKey(a => a.SalaId);
            });

            modelBuilder.Entity<Avaliacao>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasOne(a => a.Professor)
                .WithMany(p => p.Avaliacoes)
                .HasForeignKey(p => p.ProfessorId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(a => a.Aluno)
                .WithMany(p => p.Avaliacoes)
                .HasForeignKey(p => p.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);
            });
        }

    }
}
