namespace TalentInsights.Application.Models.Requests.Collaborator
{
    public class FilterCollaboratorsRequest : BaseRequest
    {

        public string? GitlabProfile { get; set; }
        public string? FullName { get; set; }
        public string? Position { get; set; }
    }
}
