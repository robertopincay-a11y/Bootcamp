using SpotifyClone.Application.Models.Dtos;
using SpotifyClone.Application.Models.Requests.User;
using SpotifyClone.Application.Models.Responses;
using SpotifyClone.Domain.Entities;

namespace SpotifyClone.Application.Interfaces.Services
{
    public interface IUserService
    {
        public GenericResponse<User> Create(CreateUserRequest model);
        public GenericResponse<List<UserDto>> Get(int limit, int offset);
        public GenericResponse<UserDto> Get(Guid userId);
        public GenericResponse<bool> Delete(Guid userId);

        public GenericResponse<bool> ChangePassword(Guid userId, ChangePasswordUserRequest model);
    }
}
