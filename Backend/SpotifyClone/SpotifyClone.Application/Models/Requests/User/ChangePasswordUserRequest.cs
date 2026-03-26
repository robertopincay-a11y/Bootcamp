using SpotifyClone.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace SpotifyClone.Application.Models.Requests.User
{
    public class ChangePasswordUserRequest
    {
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string CurrentPassword { get; set; } = null!;
        [Required(ErrorMessage = ValidationConstants.REQUIRED)]
        public string NewPassword { get; set; } = null!;
    }
}
