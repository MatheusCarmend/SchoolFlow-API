namespace SchoolFlow.API.DTOs.Auth
{
    public class RegisterDto
    {
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Role { get; set; } = "User";
    }
}

