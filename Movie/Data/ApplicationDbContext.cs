using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)
        {

        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
              am.ActorId,
              am.MovieId
            });
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(a => a.ActorId);


            base.OnModelCreating(modelBuilder);
        }
          public DbSet<Actor> Actors { get; set; }
          public DbSet<Actor_Movie> Actors_Movies { get; set; }
          public DbSet<Moviee> Movies { get; set; }
          public DbSet<Cinema> Cinemas { get; set; }
          public DbSet<Producer> Producers { get; set; }
    }
}
