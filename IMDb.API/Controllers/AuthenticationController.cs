using IMDb.Application.Interfaces.IServices;
using IMDb.Application.Services;
using IMDb.Domain.Repositories.ReadOnly;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IMDb.API.Controllers
{
    public class AuthenticationController
    {

        private readonly IUserRepositoryReadOnly _userRepositoryReadOnly;
        private readonly ITokenService _tokenService;

        public AuthenticationController(IUserRepositoryReadOnly userRepositoryReadOnly, ITokenService tokenService)
        {
            _userRepositoryReadOnly = userRepositoryReadOnly;
            _tokenService = tokenService;
        }

        public IUserRepositoryReadOnly UserRepositoryReadOnly => _userRepositoryReadOnly;

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate(string userName)
        {            
            var user = await _userRepositoryReadOnly.GetUserByName(userName);

            if (user == null)
                return new { message = "Usuário ou senha inválidos" };
            
            var token = _tokenService.GenerateToken(user);

            return new
            {
                user = user,
                token = token
            };
        }
    }
}
