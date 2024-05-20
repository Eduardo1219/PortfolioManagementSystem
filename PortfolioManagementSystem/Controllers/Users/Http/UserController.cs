using Domain.Product.Entity;
using Domain.Schedule.ScheduleCron;
using Domain.User.Entity;
using Domain.User.Entity.Enum;
using Domain.User.Service;
using Domain.Wallet.Service;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using PortfolioManagementSystem.Controllers.Users.Dto;
using PortfolioManagementSystem.Helpers.Mappers;
using Swashbuckle.AspNetCore.Annotations;

namespace PortfolioManagementSystem.Controllers.Users.Http
{
    [Route("api/[controller]")]
    [SwaggerTag("Endpoints to manage products")]
    [Produces("application/json")]
    public class UserController : Controller
    {
        private IUserService _userService;
        private IWalletService _walletService;

        public UserController(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="dto">New User</param>
        /// <response code="201">User sucessfully created</response>
        /// <response code="400">Bad Request</response>
        [HttpPost("")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddUser([FromBody] UserDto dto)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            var user = dto.UserDtoMapper();
            await _userService.AddUserAsync(user);
            
            if (user.Permission == UserEnum.Customer)
                BackgroundJob.Enqueue<IScheduleCronService>(s => s.CreateWallet(user.Id));

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="dto">User</param>
        /// <param name="Id">User Id</param>
        /// <response code="204">User sucessfully Updated</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUser([FromBody] UserDto dto, [FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest, ModelState);

            var userEntity = await _userService.GetUserByIdAsync(id);

            if (userEntity == null)
                return StatusCode(StatusCodes.Status404NotFound, "user not found");

            var entityUpdated = UserMapper.UserDtoUpdateMapper(userEntity, dto);
            await _userService.UpdateUserAsync(entityUpdated);

            return StatusCode(StatusCodes.Status204NoContent, dto);
        }

        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id">Product Id</param>
        /// <response code="200">User</response>
        /// <response code="404">Not Found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserEntity), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var userEntity = await _userService.GetUserByIdAsync(id);

            if (userEntity == null)
                return StatusCode(StatusCodes.Status404NotFound, "User not found");

            return StatusCode(StatusCodes.Status200OK, userEntity);
        }

        /// <summary>
        /// Get count users
        /// </summary>
        /// <param name="id">User Id</param>
        /// <response code="200">Count users</response>
        /// <response code="404">Not Found</response>
        [HttpGet("count")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCount([FromHeader] string? search,
            [FromHeader] string? email,
            [FromHeader] bool? active,
            [FromHeader] UserEnum? permission)
        {
            var userCount = await _userService.GetCountAsync(search, email, active, permission);

            return StatusCode(StatusCodes.Status200OK, new { Count = userCount });
        }

        /// <summary>
        /// Get paged filter users
        /// </summary>
        /// <param name="id">User Id</param>
        /// <response code="200">Count Users</response>
        /// <response code="404">Not Found</response>
        [HttpGet("filter")]
        [ProducesResponseType(typeof(List<ProductEntity>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetUsersPagedFilter([FromHeader] string? search,
            [FromHeader] string? email,
            [FromHeader] bool? active,
            [FromHeader] UserEnum? permission,
            [FromHeader] int take = 5,
            [FromHeader] int skip = 0)
        {
            var users = await _userService.GetPagedAsync(take, skip, search, email, active, permission);

            return StatusCode(StatusCodes.Status200OK, users);
        }
    }
}
