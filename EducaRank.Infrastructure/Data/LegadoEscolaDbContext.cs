using EducaRank.Infrastructure.Data.ConsultasDto;
using Microsoft.EntityFrameworkCore;

namespace EducaRank.Infrastructure.Data
{
    public class LegadoEscolaDbContext : DbContext
    {
        public LegadoEscolaDbContext(DbContextOptions<LegadoEscolaDbContext> options) : base(options) { }

        public DbSet<AlunoConsulta> AlunoBdEtec {  get; set; }
        public DbSet<ProfessorConsulta> ProfessorBdEtec { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlunoConsulta>(entity =>
            {
                entity.ToTable("tb_aluno");
                entity.HasKey(a => a.RM);
                entity.Property(a => a.RM).HasColumnName("rm");
            });

            modelBuilder.Entity<ProfessorConsulta>(entity =>
            {
                entity.ToTable("tb_professor");
                entity.HasKey(a => a.RM);
                entity.Property(a => a.RM).HasColumnName("rm");
            });

            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
