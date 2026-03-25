namespace SpotifyClone.Application.Models.Requests.User
{
    public class GetAllUsersRequest
    {
        public int? Limit { get; set; }
        public int? Offset { get; set; }
        public string? FullName { get; set; }
    }
}
