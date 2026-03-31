using Microsoft.AspNetCore.Mvc;
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
            var rsp = await collaboratorService.Create(model);
            return Ok(rsp);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] FilterCollaboratorsRequest model)
        {
            var srv = collaboratorService.Get(model);
            return Ok(srv);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var srv = await collaboratorService.Get(id);
            return Ok(srv);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCollaboratorsRequest model, Guid id)
        {
            var srv = await collaboratorService.Update(id, model);
            return Ok(srv);
        }


        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var srv = await collaboratorService.Delete(id);
            return Ok(srv);
        }
    }
}
