using Microsoft.EntityFrameworkCore;
using BrqDigitalSolutions.Models;

namespace BrqDigitalSolutions.DBContext
{
  public class BaseContext : DbContext
  {
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Candidate> Candidates { get; set; } = default!;

    public DbSet<Skill> Skills { get; set; } = default!;

    public DbSet<CandidateSkill> CandidateSkills { get; set; } = default!;

    public DbSet<Certification> Certifications { get; set; } = default!;

    public override int SaveChanges()
    {
      var entries = ChangeTracker
          .Entries()
          .Where(e => e.Entity is Timestamp && (
                  e.State == EntityState.Added
                  || e.State == EntityState.Modified));

      foreach (var entityEntry in entries)
      {
        ((Timestamp)entityEntry.Entity).UpdatedAt = DateTime.Now;

        if (entityEntry.State == EntityState.Added)
        {
          ((Timestamp)entityEntry.Entity).CreatedAt = DateTime.Now;
        }
      }

      return base.SaveChanges();
    }
  }
}
