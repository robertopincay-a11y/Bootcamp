using SpotifyClone.Application.Helpers;
using SpotifyClone.Application.Interfaces.Services;
using SpotifyClone.Application.Models.Dtos;
using SpotifyClone.Application.Models.Requests.User;
using SpotifyClone.Application.Models.Responses;
using SpotifyClone.Domain.Entities;
using SpotifyClone.Shared;
using SpotifyClone.Shared.Helpers;

namespace SpotifyClone.Application.Services
{
    public class UserService(Cache<User> cache) : IUserService
    {


        public GenericResponse<UserDto> Create(CreateUserRequest model)
        {
            var user = new User
            {
                UsuarioId = Guid.NewGuid(),
                TipoCuenta = "Oyente",
                Membership = "No premium",
                Nombre = model.FullName,
                Email = model.Email,
                Password = model.Password,
                IsActive = true,
                CreatedAt = DateTimeHelper.UtcNow(),
                JoinedAt = DateTimeHelper.UtcNow()
            };

            var userDto = new UserDto
            {
                UsuarioId = user.UsuarioId,
                TipoCuenta = user.TipoCuenta,
                Membership = user.Membership,
                Nombre = user.Nombre,
                Email = user.Email,
                CreatedAt = user.CreatedAt,
                JoinedAt = user.JoinedAt
            };

            cache.Add(user.UsuarioId.ToString(), user);

            return ResponseHelper.Create(userDto, "Usuario Creado con exito");
        }

        public GenericResponse<bool> Delete(Guid userId)
        {
            var SiExiste = cache.Get(userId.ToString());

            if (SiExiste is null)
            {
                return ResponseHelper.Create(false);
            }
            cache.Delete(userId.ToString());

            return ResponseHelper.Create(true);
        }

        public GenericResponse<List<UserDto>> Get(int limit, int offset)
        {
            var users = cache.Get();
            return ResponseHelper.Create(users);
        }


        public GenericResponse<UserDto> Get(Guid UserId)
        {
            var user = cache.Get(UserId.ToString());

            return ResponseHelper.Create(user);


        }

        public GenericResponse<bool> ChangePassword(Guid userId, ChangePasswordUserRequest model)
        {
            var rsp = cache.Get(userId.ToString());
            if (rsp is not null)
            {
                rsp.
            }



            return ResponseHelper.Create(true);
        }
    }
}
