using SpotifyClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace SpotifyClone.Application.Models.Requests.User
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(100, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(3, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public required string FullName { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(255, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(10, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        [MaxLength(100, ErrorMessage = ValidationConstants.MAX_LENGTH)]
        [MinLength(5, ErrorMessage = ValidationConstants.MIN_LENGTH)]
        public required string Password { get; set; }


    }
}
