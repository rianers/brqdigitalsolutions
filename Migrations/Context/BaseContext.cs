using DataProvider.DataModels;
using Microsoft.EntityFrameworkCore;

namespace Migrations.Context
{
    public class BaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=34.236.8.155;Database=brq_challenger;Username=postgres;Password=admin_fiap_pgsql");
        }

        public DbSet<Candidate> Candidates { get; set; } = default!;

        public DbSet<Skill> Skills { get; set; } = default!;

        public DbSet<CandidateSkill> CandidateSkills { get; set; } = default!;

        public DbSet<Certification> Certifications { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CandidateSkill>()
                .HasKey(bc => new { bc.CandidateId, bc.SkillId });
            modelBuilder.Entity<CandidateSkill>()
                .HasOne(bc => bc.Candidate)
                .WithMany(b => b.Skills)
                .HasForeignKey(bc => bc.CandidateId);
            modelBuilder.Entity<CandidateSkill>()
                .HasOne(bc => bc.Skill)
                .WithMany(c => c.Candidates)
                .HasForeignKey(bc => bc.SkillId);
        }
    }
}