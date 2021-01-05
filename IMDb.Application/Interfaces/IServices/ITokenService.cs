using IMDb.Domain.Entity;

namespace IMDb.Application.Interfaces.IServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
