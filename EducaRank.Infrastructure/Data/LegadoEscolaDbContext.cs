using EducaRank.Infrastructure.Data.ConsultasDto;
using Microsoft.EntityFrameworkCore;

namespace EducaRank.Infrastructure.Data
{
    public class LegadoEscolaDbContext : DbContext
    {
        public LegadoEscolaDbContext(DbContextOptions<LegadoEscolaDbContext> options) : base(options)
        {
        }

        public DbSet<AlunoConsulta> AlunoBdEtec { get; set; } = null!;
        public DbSet<ProfessorConsulta> ProfessorBdEtec { get; set; } = null!;
        public DbSet<MateriaConsulta> MateriaBdEtec { get; set; } = null!;
        public DbSet<ProfessorMateriaConsulta> ProfessorMateriaBdEtec { get; set; } = null!;
        public DbSet<SalaConsulta> SalaBdEtec { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AlunoConsulta>(entity =>
            {
                entity.HasKey(a => a.RM);
                entity.ToTable("tb_aluno");
            });

            modelBuilder.Entity<ProfessorConsulta>(entity =>
            {
                entity.HasKey(a => a.RM);
                entity.ToTable("tb_professor");
            });

            modelBuilder.Entity<MateriaConsulta>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.ToTable("tb_materia");
            });

            modelBuilder.Entity<ProfessorMateriaConsulta>(entity =>
            {
                entity.HasKey(pm => new { pm.RMProfessor, pm.IdMateria });
                entity.ToTable("professor_materia");
            });

            modelBuilder.Entity<SalaConsulta>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.ToTable("tb_sala");
            });
        }
    }
}
