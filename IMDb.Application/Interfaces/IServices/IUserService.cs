using IMDb.CrossCutting.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Application.Interfaces.IServices
{
    public interface IUserService
    {
        Task<bool>  RegisterUser(UserDto user);
        Task<bool> EditUser(UserDto user);
        Task<bool> DeactivateUser(int userID);
        Task<bool> RegisterAdmin(AdminDto user);
        Task<bool> EditAdmin(AdminDto user);
        Task<List<UserDto>> GetUsers(int pageNumber, int quantity);
    }
}
