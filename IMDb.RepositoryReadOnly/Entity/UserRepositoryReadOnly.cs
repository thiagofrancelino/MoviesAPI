using Dapper;
using IMDb.Domain.Entity;
using IMDb.Domain.Repositories.ReadOnly;
using IMDb.RepositoryReadOnly.Architecture;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.RepositoryReadOnly.Entity
{
    public class UserRepositoryReadOnly : BaseRepositoryReadOnly, IUserRepositoryReadOnly
    {
        public async Task<User> GetUserByName(string userName)
        {
            var sql = $@"SELECT  UserID ,
                                    Name,
                                    IsAdmin
                            FROM    Users WITH(NOLOCK)
                            WHERE Name = '{userName} '";

            return await WithConnection(async db =>
            {
                var result = await db.QueryAsync<User>(sql);
                return result.First();
            });
        }

        public async Task<IQueryable<User>> GetUsers(int pageNumber, int quantity)
        {
            var sql = $@"SELECT  UserID ,
                                    Name,
                                    IsAdmin
                            FROM    Users WITH(NOLOCK)
                            WHERE Name = 'a '";

            return await WithConnection(async db =>
            {
                var result = await db.QueryAsync<User>(sql);
                return result.AsQueryable();
            });
        }
    }
}
