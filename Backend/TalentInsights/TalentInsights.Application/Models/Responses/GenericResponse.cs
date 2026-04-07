namespace TalentInsights.Application.Models.Responses
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; } = [];
        public DateTime Time { get; } = DateTimeOffset.UtcNow.DateTime;
        public T Data { get; set; }



    }
}
