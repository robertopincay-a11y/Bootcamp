namespace SpotifyClone.Application.Models.Dtos
{
    public class UserDto
    {
        public Guid UsuarioId { get; set; }
        public string TipoCuenta { get; set; } = null!;
        public string Membership { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime JoinedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
