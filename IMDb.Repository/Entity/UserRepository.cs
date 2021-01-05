using IMDb.CrossCutting.Enums;
using IMDb.Domain.Entity;
using IMDb.Domain.Repositories;
using IMDb.Infra;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.Repository.Entity
{
    public class UserRepository : IUserRepository
    {
        private readonly IMDbContext _iMDbContext;

        public UserRepository(IMDbContext iMDbContext)
        {
            _iMDbContext = iMDbContext;
        }

        public async Task<bool> RegisterUser(User user)
        {
            _iMDbContext.Users.Add(user);
            await _iMDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<User> EditUser(User user)
        {
            var entity = _iMDbContext.Users.Single(b => b.UserID == user.UserID);

            if (entity != null)
            {
                entity.Name = user.Name;
                entity.RecordDate = user.RecordDate;
                entity.IsAdmin = user.IsAdmin;
                entity.StatusID = user.StatusID;

                await _iMDbContext.SaveChangesAsync();

                return entity;
            }
            return null;
        }

        public async Task<bool> DeactivateUser(int userID)
        {
            var entity = _iMDbContext.Users.Single(b => b.UserID == userID);

            if (entity != null)
            {
                entity.StatusID = (int)EStatus.Inactive;

                await _iMDbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<IQueryable<User>> GetUsers(int pageNumber, int quantity )
        {
            if(pageNumber == 0 && quantity == 0)
            {
                return _iMDbContext.Users.Where(b => !b.IsAdmin);
            }
            else if(pageNumber == 0)
            {
                return _iMDbContext.Users.Where(b => !b.IsAdmin).Take(quantity);
            }
            else
            {
                return _iMDbContext.Users.Where(b => !b.IsAdmin).Skip(quantity * (pageNumber - 1)).Take(quantity * pageNumber);
            }                                   
        }

    }
}
