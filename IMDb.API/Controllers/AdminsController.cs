using IMDb.Application.Interfaces.IServices;
using IMDb.CrossCutting.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IMDb.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminsController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="adminDto">User</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost("/admins")]
        public async Task<IActionResult> RegisterAdmin(AdminDto adminDto)
        {
            var result = await _userService.RegisterAdmin(adminDto);
            return await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="adminDto">User</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPut("/admins")]
        public async Task<IActionResult> EditAdmin(UserDto userDto)
        {
            var result = await _userService.EditUser(userDto);
            return await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="userID">User</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpDelete("/admins")]
        public async Task<IActionResult> DeactivateAdmin(int userID)
        {
            var result = await _userService.DeactivateUser(userID);
            return await Task.FromResult(Ok(result));
        }
    }
}
