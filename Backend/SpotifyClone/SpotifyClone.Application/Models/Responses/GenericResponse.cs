using SpotifyClone.Shared.Helpers;

namespace SpotifyClone.Application.Models.Responses
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public DateTime Time { get; set; } = DateTimeHelper.UtcNow();
        public T Data { get; set; }
    }
}
