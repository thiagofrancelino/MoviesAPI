using IMDb.Domain.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<bool> RegisterUser(User user);

        Task<User> EditUser(User user);

        Task<bool> DeactivateUser(int userID);

        Task<IQueryable<User>> GetUsers(int pageNumber, int quantity);
    }
}
