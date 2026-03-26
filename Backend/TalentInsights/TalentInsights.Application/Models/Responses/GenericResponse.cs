namespace TalentInsights.Application.Models.Responses
{
    public class GenericResponse<T>
    {
        public string Message { get; set; }
        public DateTime Time { get; } = DateTimeOffset.UtcNow.DateTime;
        public T Data { get; set; }



    }
}
