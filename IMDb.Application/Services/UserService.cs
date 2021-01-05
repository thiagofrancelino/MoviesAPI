using IMDb.Application.Interfaces.IMapper;
using IMDb.Application.Interfaces.IServices;
using IMDb.CrossCutting.Dto;
using IMDb.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMDb.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserMapper _userMapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserMapper userMapper, IUserRepository userRepository)
        {
            _userMapper = userMapper;
            _userRepository = userRepository;
        }                        

        public async Task<bool> RegisterUser(UserDto user)
        {
            var newUser = _userMapper.MapUserDtoToEntity(user);
            var result = await _userRepository.RegisterUser(newUser);

            return result;
        }
        public async Task<bool> EditUser(UserDto user)
        {
            var newUser = _userMapper.MapUserDtoToEntity(user);
            await _userRepository.EditUser(newUser);

            return true;
        }

        public async Task<bool> DeactivateUser(int userID)
        {            
            var result = await _userRepository.DeactivateUser(userID);

            return result;
        }

        public async Task<bool> RegisterAdmin(AdminDto admin)
        {
            var newUser = _userMapper.MapAdminDtoToEntity(admin);
            var result = await _userRepository.RegisterUser(newUser);

            return result;
        }
        public async Task<bool> EditAdmin(AdminDto admin)
        {
            var newUser = _userMapper.MapAdminDtoToEntity(admin);
            await _userRepository.EditUser(newUser);

            return true;
        }

        public async Task<List<UserDto>> GetUsers(int pageNumber, int quantity)
        {            
            var users = await _userRepository.GetUsers(pageNumber, quantity);

            var result = new List<UserDto>();

            foreach (var u in users)
            {
                result.Add(_userMapper.MapUserEntityToDto(u));
            }           

            return result;
        }
    }
}
