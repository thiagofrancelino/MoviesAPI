using IMDb.CrossCutting.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Application.Interfaces.Services
{
    public interface IMovieService
    {
        Task<List<MovieDto>> GetMovies(string movieName, int genderID, int directorID);
        Task<bool> RegisterMovie(MovieDto movieDto);
        Task<bool> RegisterRate(MovieRateDto rateDto);
    }
}
