
using SpotifyClone.Application.Models.Responses;

namespace SpotifyClone.Application.Helpers
{
    public static class ResponseHelper
    {
        public static GenericResponse<T> Create<T>(T data, string message = "Solicitud realizada correctamente")
        {
            return new GenericResponse<T>
            {
                Data = data,
                Message = message
            };
        }
    }
}
