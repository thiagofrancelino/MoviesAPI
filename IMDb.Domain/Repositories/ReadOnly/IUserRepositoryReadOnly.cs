using IMDb.Domain.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Domain.Repositories.ReadOnly
{
    public interface IUserRepositoryReadOnly
    {
        Task<User> GetUserByName(string userName);
        Task<IQueryable<User>> GetUsers(int pageNumber, int quantity);
    }
}
