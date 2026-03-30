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

        public GenericResponse<List<UserDto>> Get(int limit, int offset)
        {
            var users = cache.Get();
            var lista = new List<UserDto>();

            foreach (var user in users)
            {
                var usersDto = new UserDto
                {
                    UsuarioId = user.UsuarioId,
                    TipoCuenta = user.TipoCuenta,
                    Membership = user.Membership,
                    Nombre = user.Nombre,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    JoinedAt = user.JoinedAt
                };
                lista.Add(usersDto);
            }

            return ResponseHelper.Create(lista);
        }


        public GenericResponse<UserDto> Get(Guid UserId)
        {
            var user = cache.Get(UserId.ToString());
            UserDto userDto;
            if (user is not null)
            {
                userDto = new UserDto
                {
                    UsuarioId = user.UsuarioId,
                    TipoCuenta = user.TipoCuenta,
                    Membership = user.Membership,
                    Nombre = user.Nombre,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    JoinedAt = user.JoinedAt
                };
            }
            else
            {
                userDto = null;
            }

            return ResponseHelper.Create(userDto);

        }

        public GenericResponse<bool> ChangePassword(Guid userId, ChangePasswordUserRequest model)
        {
            var rsp = cache.Get(userId.ToString());
            if (rsp is not null)
            {
                if (rsp.Password != model.CurrentPassword)
                {

                    return ResponseHelper.Create(false);
                }
                else
                {
                    rsp.Password = model.NewPassword;
                    return ResponseHelper.Create(true);
                }
            }
            else
            {
                return ResponseHelper.Create(false);
            }


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

    }
}
