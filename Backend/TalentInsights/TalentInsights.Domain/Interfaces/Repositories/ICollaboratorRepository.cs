using TalentInsights.Domain.Database.SqlServer.Entities;

namespace TalentInsights.Domain.Interfaces.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<Collaborator> Create(Collaborator collaborator);
        Task<Collaborator?> Get(Guid collaboratorId);
        IQueryable<Collaborator> Queryable();
        Task<bool> IfExist(Guid collaboratorId);
        //Task<bool> IfExist(string username); en caso de existir otro usuario con mismo nombre
        Task<Collaborator> Update(Collaborator collaborator);

    }
}
