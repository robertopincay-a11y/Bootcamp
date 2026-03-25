using Microsoft.AspNetCore.Mvc;
using TalentInsights.Application.Models.Requests.Collaborator;

namespace TalentInsights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCollaboratorRequest model)
        {

            return Ok($"Usuario:{model.FullName} creado!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int limit, [FromQuery] int offset)
        {
            return Ok($"Todos los usuarios: limit:{limit}, offset:{offset}");
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok($"{id}");
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCollaboratorsRequest model, Guid id)
        {
            return Ok($"Usuario Actualizado: {id} - {model.FullName}");
        }

        [HttpPatch("change-password/{id:guid}")]
        public async Task<IActionResult> ChangePassword(Guid id, [FromBody] ChangePasswordCollaboratorRequest model)
        {
            return Ok($"Contrasena cambiada:{model.CurrentPassword} {model.NewPassword}");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok($"Usuario Eliminado: {id}");
        }
    }
}
