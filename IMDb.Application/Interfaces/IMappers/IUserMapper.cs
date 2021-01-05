using IMDb.CrossCutting.Dto;
using IMDb.Domain.Entity;

namespace IMDb.Application.Interfaces.IMapper
{
    public interface IUserMapper
    {
        User MapUserDtoToEntity(UserDto dto);
        User MapAdminDtoToEntity(AdminDto dto);
        UserDto MapUserEntityToDto(User user);
    }
}
