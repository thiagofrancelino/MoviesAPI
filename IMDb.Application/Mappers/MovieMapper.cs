using IMDb.Application.Interfaces.IMapper;
using IMDb.CrossCutting.Dto;
using IMDb.CrossCutting.Enums;
using IMDb.Domain.Entity;
using System;

namespace IMDb.Application.Mappers
{
    public class MovieMapper : IMovieMapper
    {
        public Movie MapDtoToEntity(MovieDto dto)
        {            
            return new Movie() { Name = dto.Name, GenderID = dto.GenderID, RecordDate = DateTime.Now, ActorsIDs = dto.Actors, StatusID = (int)EStatus.Active, DirectorID = dto.DirectorID};
        }

        public MovieRate MapRateDtoToEntity(MovieRateDto dto)
        {
            return new MovieRate() { UserID = dto.UserID, MovieID = dto.MovieID, RecordDate = DateTime.Now};
        }
    }
}
