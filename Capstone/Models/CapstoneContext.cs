using Microsoft.EntityFrameworkCore;

namespace Capstone.Models
{
  public class CapstoneContext : DbContext // these will become tables in the database
  {
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Show> Shows { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<ActingCredit> ActingCredit { get; set; }
    public DbSet<GenreShow> GenreShow { get; set; }

    public CapstoneContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies(); // proxies are needed to use lazy loading
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<ActingCredit>().HasKey(ac => new { ac.ActorId, ac.ShowId });
    // }
  }
}