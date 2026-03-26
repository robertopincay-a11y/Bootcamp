using Microsoft.AspNetCore.Mvc;
using TalentInsights.Application.Helpers;
using TalentInsights.Application.Interfaces.Services;
using TalentInsights.Application.Models.Requests.Collaborator;

namespace TalentInsights.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController(ICollaboratorService collaboratorService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCollaboratorRequest model)
        {
            var rsp = collaboratorService.Create(model);
            return Ok($"Usuario:{model.FullName} creado!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCollaboratorsRequest model)
        {
            List<string> users = ["Usuario 1", "Usuario 2", "Usuario 3"];

            return Ok(ResponseHelper.Create(users));
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var usuarioId = $"{id}";

            return Ok(ResponseHelper.Create($"{usuarioId}"));
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
