using IMDb.Domain.Entity;
using System.Threading.Tasks;

namespace IMDb.Domain.Repositories
{
    public interface IMovieRateRepository
    {
        Task<bool> RegisterRate(MovieRate rate);
    }
}
