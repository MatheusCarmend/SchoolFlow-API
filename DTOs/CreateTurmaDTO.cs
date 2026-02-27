using System.ComponentModel.DataAnnotations;

namespace SchoolFlow.API.DTOs
{
    public class CreateTurmaDto
    {
        [Required(ErrorMessage = "O nome da turma é obrigatório")]
        [MinLength(3, ErrorMessage = "O nome da turma deve ter no mínimo 3 caracteres")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O professor é obrigatório")]
        public int ProfessorId { get; set; }
        public int Ano { get; set; }
        public string Periodo { get; set; } = string.Empty;
    }
}

