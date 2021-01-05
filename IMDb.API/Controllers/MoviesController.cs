using IMDb.Application.Interfaces.Services;
using IMDb.CrossCutting.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Retorna Lista de Produtos da industria
        /// </summary>
        /// <param name="movieName">Movie Name</param>
        /// <param name="genderID">Gender ID</param>
        /// <param name="directorID">Director ID</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(List<MovieDto>), 200)]
        [HttpGet("/movies")]
        public async Task<IActionResult> GetUsers(string movieName, int genderID = 0, int directorID = 0)
        {
            var users = await _movieService.GetMovies(movieName, genderID, directorID);
            return await Task.FromResult(Ok(users));
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="movieDto">Movie</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost("/movies")]
        public async Task<IActionResult> RegisterMovie(MovieDto movieDto)
        {
            var result = await _movieService.RegisterMovie(movieDto);
            return await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="rateDto">Movie</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost("/movies/rate")]
        [Authorize]
        public async Task<IActionResult> RegisterRate(MovieRateDto rateDto)
        {
            var result = await _movieService.RegisterRate(rateDto);
            return await Task.FromResult(Ok(result));
        }


    }
}
