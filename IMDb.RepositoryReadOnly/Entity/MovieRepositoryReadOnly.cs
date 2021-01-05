using Dapper;
using IMDb.CrossCutting.Dto;
using IMDb.Domain.Repositories.ReadOnly;
using IMDb.RepositoryReadOnly.Architecture;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.RepositoryReadOnly.Movies
{
    public class MovieRepositoryReadOnly : BaseRepositoryReadOnly, IMovieRepositoryReadOnly
    {
        public async Task<List<MovieDto>> GetAll(string movieName, int genderID, int directorID)
        {
            var nullString = "NULL";
            var sql = $@"DECLARE @MovieName VARCHAR = {(!string.IsNullOrEmpty(movieName) ? movieName : nullString)};
                                DECLARE @GenderID INT = {(genderID > 0 ? genderID : nullString)};
                                DECLARE @DirectorID INT = {(directorID > 0 ? directorID : nullString)};

                                  SELECT MovieID
                                      ,Name
                                      ,RecordDate
                                      ,GenderID
                                      ,StatusID
	                                  ,DirectorID
                                  FROM [dbo].[Movies] WITH(NOLOCK)
                                  WHERE (@MovieName IS NULL OR (@MovieName IS NOT NULL AND Name = @MovieName)) AND
                                  (@GenderID IS NULL OR (@GenderID IS NOT NULL AND GenderID = @GenderID)) AND
                                  (@DirectorID IS NULL OR (@DirectorID IS NOT NULL AND DirectorID = @DirectorID))";

            return await WithConnection(async db =>
            {
                var result = await db.QueryAsync<MovieDto>(sql);
                return result.ToList();
            });
        }


    }
}
