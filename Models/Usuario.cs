namespace SchoolFlow.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;

        public string SenhaHash { get; set; } = null!;

        public string Role { get; set; } = "User"; // Admin, User
        public bool Ativo { get; set; } = true;
    }
}

