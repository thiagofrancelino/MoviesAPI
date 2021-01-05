using IMDb.Domain.Entity;
using IMDb.Domain.Repositories;
using IMDb.Infra;
using System.Threading.Tasks;

namespace IMDb.Repository.Entity
{
    public class MovieRateRepository : IMovieRateRepository
    {
        private readonly IMDbContext _iMDbContext;

        public MovieRateRepository(IMDbContext iMDbContext)
        {
            _iMDbContext = iMDbContext;
        }

        public async Task<bool> RegisterRate(MovieRate rate)
        {
            _iMDbContext.MovieRates.Add(rate);
            await _iMDbContext.SaveChangesAsync();

            return true;
        }
    }
}
