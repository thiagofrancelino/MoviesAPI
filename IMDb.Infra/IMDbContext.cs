using IMDb.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace IMDb.Infra
{
    public class IMDbContext : DbContext
    {
        public IMDbContext(DbContextOptions<IMDbContext> options)
           : base(options)
        {}

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users {get;set;}
        public DbSet<Status> Status { get; set; }
        public DbSet<MovieRate> MovieRates { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }
        public DbSet<Director> Directors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().ToTable("Actors");
            modelBuilder.Entity<Gender>().ToTable("Genders");
            modelBuilder.Entity<Movie>().ToTable("Movies");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Status>().ToTable("Status");
            modelBuilder.Entity<MovieRate>().ToTable("MovieRates").HasOne(s => s.User)
                                                                  .WithMany(g => g.MovieRates)
                                                                  .HasForeignKey(s => s.UserID)
                                                                  .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MoviesActors>().ToTable("MoviesActors").HasKey(ma => new { ma.ActorID, ma.MovieID });
            modelBuilder.Entity<Director>().ToTable("Directors");
        }
    }
}
