using EducaRank.Infrastructure.Data.ConsultasDto;
using Microsoft.EntityFrameworkCore;

namespace EducaRank.Infrastructure.Data
{
    public class LegadoEscolaDbContext : DbContext
    {
        public LegadoEscolaDbContext(DbContextOptions<LegadoEscolaDbContext> options) : base(options)
        {
        }

        // DbSets usados apenas para consulta (não são entidades persistidas pelo EF)
        public DbSet<AlunoConsulta> AlunoBdEtec { get; set; } = null!;
        //public DbSet<ProfessorConsulta> ProfessorBdEtec { get; set; } = null!;
        //public DbSet<SalaConsulta> SalaBdEtec { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AlunoConsulta>(entity =>
            {
                entity.HasKey(a => a.RM);
                entity.ToTable("tb_aluno");
            });

        }
    }
}
