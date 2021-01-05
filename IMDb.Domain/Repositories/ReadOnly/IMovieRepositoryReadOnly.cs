using IMDb.CrossCutting.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDb.Domain.Repositories.ReadOnly
{
    public interface IMovieRepositoryReadOnly
    {
        Task<List<MovieDto>> GetAll(string movieName, int genderID, int directorID);
    }
}
