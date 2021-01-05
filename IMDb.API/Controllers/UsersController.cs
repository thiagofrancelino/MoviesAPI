using IMDb.Application.Interfaces.IServices;
using IMDb.CrossCutting.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }        

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="userDto">User</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPost("/users")]
        public async Task<IActionResult> RegisterUser(UserDto userDto)
        {
            var result = await _userService.RegisterUser(userDto);
            return await Task.FromResult(Ok(result));
        }

        /// <summary>
        /// Register new User
        /// </summary>
        /// <param name="userDto">User</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(bool), 200)]
        [HttpPut("/users")]
        public async Task<IActionResult> EditUser(UserDto userDto)
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
        [HttpDelete("/users")]
        public async Task<IActionResult> DeactivateUser(int userID)
        {
            var result = await _userService.DeactivateUser(userID);
            return await Task.FromResult(Ok(result));
        }


        /// <summary>
        /// Retorna Lista de Produtos da industria
        /// </summary>
        /// <param name="pageNumber">Page Number</param>
        /// <param name="quantity">Number of Records</param>
        /// <returns  code="500">Erro interno</returns>
        [ProducesResponseType(typeof(List<UserDto>), 200)]
        [HttpGet("/admins/users")]
        public async Task<IActionResult> GetUsers(int pageNumber = 0, int quantity = 0)
        {
            var users = await _userService.GetUsers(pageNumber, quantity);
            return await Task.FromResult(Ok(users));
        }
    }
}
