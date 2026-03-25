using SpotifyClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace SpotifyClone.Application.Models.Requests.User
{
    public class UpdateUsersRequest
    {
        [MaxLength(100, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(3, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string? FullName { get; set; }

        [MaxLength(255, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(45, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string? Correo { get; set; }

        [MaxLength(100, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(5, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public string? Password { get; set; }
    }
}
