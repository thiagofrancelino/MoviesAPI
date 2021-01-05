using IMDb.Domain.Entity;
using System.Threading.Tasks;

namespace IMDb.Domain.Repositories
{
    public interface IMovieRepository
    {
        Task<bool> RegisterMovie(Movie movie);
    }
}
