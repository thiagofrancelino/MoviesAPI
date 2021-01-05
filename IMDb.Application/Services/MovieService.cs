using IMDb.Application.Interfaces.IMapper;
using IMDb.Application.Interfaces.Services;
using IMDb.CrossCutting.Dto;
using IMDb.Domain.Repositories;
using IMDb.Domain.Repositories.ReadOnly;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository; 
        private readonly IMovieRepositoryReadOnly _movieRepositoryReadOnly;
        private readonly IMovieRateRepository _movieRateRepository;
        private readonly IMovieMapper _movieMapper;

        public MovieService(IMovieRepositoryReadOnly movieRepositoryReadOnly, IMovieMapper movieMapper, IMovieRepository movieRepository, IMovieRateRepository movieRateRepository)
        {
            _movieRepositoryReadOnly = movieRepositoryReadOnly;
            _movieMapper = movieMapper;
            _movieRepository = movieRepository;
            _movieRateRepository = movieRateRepository;
        }

        public async Task<List<MovieDto>> GetMovies(string movieName, int genderID, int directorID)
        {
            var movies = await _movieRepositoryReadOnly.GetAll(movieName, genderID, directorID);
            
            return await Task.FromResult(movies);
        }

        public async Task<bool> RegisterMovie(MovieDto movieDto)
        {

            var movie = _movieMapper.MapDtoToEntity(movieDto);
            var result = await _movieRepository.RegisterMovie(movie);

            return await Task.FromResult(result);
        }

        public async Task<bool> RegisterRate(MovieRateDto movieDto)
        {

            var rate = _movieMapper.MapRateDtoToEntity(movieDto);
            var result = await _movieRateRepository.RegisterRate(rate);

            return await Task.FromResult(result);
        }
    }
}
