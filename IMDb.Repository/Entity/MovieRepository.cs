using IMDb.Domain.Entity;
using IMDb.Domain.Repositories;
using IMDb.Infra;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Repository.Entity
{
    public class MovieRepository : IMovieRepository
    {
        private readonly IMDbContext _iMDbContext;

        public MovieRepository(IMDbContext iMDbContext)
        {
            _iMDbContext = iMDbContext;
        }

        public async Task<bool> RegisterMovie(Movie movie)
        {
            movie.MoviesActors = new List<MoviesActors>();

            foreach (var actorID in movie.ActorsIDs)
            {
                var actor = _iMDbContext.Actors.First(x => x.ActorID == actorID);
                if (actor != null)
                {
                    var link = new MoviesActors() { Actor = actor, Movie = movie };
                    movie.MoviesActors.Add(link);
                }                  
            }

            _iMDbContext.Movies.Add(movie);
            await _iMDbContext.SaveChangesAsync();

            return true;
        }
    }
}
