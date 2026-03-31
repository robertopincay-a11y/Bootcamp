using TalentInsights.Application.Models.Dtos;
using TalentInsights.Application.Models.Requests.Collaborator;
using TalentInsights.Application.Models.Responses;

namespace TalentInsights.Application.Interfaces.Services
{
    public interface ICollaboratorService
    {
        public Task<GenericResponse<CollaboratorDto>> Create(CreateCollaboratorRequest model);
        public Task<GenericResponse<CollaboratorDto>> Update(Guid collaboratorId, UpdateCollaboratorsRequest model);
        public GenericResponse<List<CollaboratorDto>> Get(FilterCollaboratorsRequest model);
        public Task<GenericResponse<CollaboratorDto>> Get(Guid collaboratorId);
        public Task<GenericResponse<bool>> Delete(Guid collaboratorId);
    }
}
