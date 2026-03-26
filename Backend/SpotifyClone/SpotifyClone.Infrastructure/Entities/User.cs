namespace SpotifyClone.Domain.Entities
{
    public class User
    {
        public Guid UsuarioId { get; set; }
        public string TipoCuenta { get; set; } = null!;
        public string Membership { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime JoinedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
