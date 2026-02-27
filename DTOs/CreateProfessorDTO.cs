using System.ComponentModel.DataAnnotations;

namespace SchoolFlow.API.DTOs
{
    public class CreateProfessorDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória")]
        public string Especialidade { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [MinLength(8, ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; }
    }
}
