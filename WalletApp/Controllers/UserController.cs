using Microsoft.AspNetCore.Mvc;
using WalletApp.Business.Dto;
using WalletApp.Business.Services.Interfaces;

namespace WalletApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserDto userDto)
        {
            var user = await _userService.CreateUserAsync(userDto);
            return Ok(user);
        }

        [HttpGet("points/{userId}")]
        public async Task<IActionResult> GetCardBalance([FromQuery] int id)
        {
            var points = await _userService.CalculatePointsAsync(id);
            return Ok(points);
        }
    }
}
