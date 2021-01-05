using IMDb.CrossCutting.Dto;
using IMDb.Domain.Entity;

namespace IMDb.Application.Interfaces.IMapper
{
    public interface IMovieMapper
    {
        Movie MapDtoToEntity(MovieDto dto);
        MovieRate MapRateDtoToEntity(MovieRateDto dto);
    }
}
