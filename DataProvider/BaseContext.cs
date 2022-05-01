using DataProvider.DataModels;
using Microsoft.EntityFrameworkCore;

namespace DataProvider
{
  public class BaseContext : DbContext
  {
    public BaseContext(DbContextOptions<BaseContext> options) : base(options)
    {
      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("Host=34.236.8.155;Database=brq_challenger;Username=postgres;Password=admin_fiap_pgsql");
      AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public DbSet<Candidate> Candidates { get; set; } = default!;

    public DbSet<Skill> Skills { get; set; } = default!;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Candidate>()
          .HasMany<Skill>(c => c.Skills)
          .WithMany(s => s.Candidates)
          .Map(cs =>
          {
            cs.MapLeftKey("candidate_id");
            cs.MapRightKey("skill_id");
            cs.ToTable("candidate_skills");
          });
    }
  }
}
