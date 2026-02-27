using System.ComponentModel.DataAnnotations;

namespace SchoolFlow.API.DTOs
{
    public class CreateAlunoDto
    {
        [Required]
        public string Nome { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; } = null!;
        [Required]
        public int TurmaId { get; set; }
    }
}
