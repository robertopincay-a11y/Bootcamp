using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Application.Helpers;
using SpotifyClone.Application.Interfaces.Services;
using SpotifyClone.Application.Models.Requests.User;

namespace SpotifyClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest model)
        {
            var resp = userService.Create(model);
            return Ok(resp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllUsersRequest model)
        {
            return Ok(ResponseHelper.Create(userService.Get(model.Limit ?? 0, model.Offset ?? 0)));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rsp = userService.Get(id);
            return Ok(rsp);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rsp = userService.Delete(id);
            return Ok(rsp);
        }

        [HttpPut("change-password/{id:guid}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordUserRequest model)
        {
            var rsp = userService.ChangePassword(id, model);
            return Ok(rsp);
        }

    }
}
