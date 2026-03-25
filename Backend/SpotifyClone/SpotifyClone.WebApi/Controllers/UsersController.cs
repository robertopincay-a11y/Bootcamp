using Microsoft.AspNetCore.Mvc;
using SpotifyClone.Application.Models.Requests.User;

namespace SpotifyClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest model)
        {
            return Ok($"Usuario:{model.FullName} creado!");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromBody] GetAllUsersRequest model)
        {
            return Ok($"Todos los usuarios: usuario:{model.FullName} limit:{model.Limit}, offset:{model.Offset}");
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUsersRequest model, Guid id)
        {
            return Ok($"Usuario Actualizado: {id} - {model.FullName}");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok($"Usuario Eliminado: {id}");
        }
    }
}
