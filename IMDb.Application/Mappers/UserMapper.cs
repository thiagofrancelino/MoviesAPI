using IMDb.Application.Interfaces.IMapper;
using IMDb.CrossCutting.Dto;
using IMDb.CrossCutting.Enums;
using IMDb.Domain.Entity;
using System;

namespace IMDb.Application.Mappers
{
    public class UserMapper : IUserMapper
    {
        public User MapUserDtoToEntity(UserDto dto)
        {
            return new User() { UserID = dto.UserID, Name = dto.Name, RecordDate = DateTime.Now, StatusID = (int)EStatus.Active, IsAdmin =  false } ;
        }

        public User MapAdminDtoToEntity(AdminDto dto)
        {
            return new User() { UserID = dto.UserID, Name = dto.Name, RecordDate = DateTime.Now, StatusID = (int)EStatus.Active, IsAdmin = true };
        }

        public UserDto MapUserEntityToDto(User user)
        {
            return new UserDto() { UserID = user.UserID, Name = user.Name};
        }
    }
}
