using Microsoft.EntityFrameworkCore;

namespace Capstone.Models
{
  public class CapstoneContext : DbContext // these will become tables in the database
  {
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<ActingCredit>().HasKey(ac => new { ac.ActorId, ac.ShowId});
    }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<ActingCredit> ActingCredits { get; set; }

    public CapstoneContext(DbContextOptions options) : base(options) { }
  }
}