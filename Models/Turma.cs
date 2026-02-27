using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SchoolFlow.API.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int Ano { get; set; }
        public string Periodo { get; set; } = null!;
        public bool Ativa { get; set; } = true;

        // Relacionamento com Professor
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; } = null!;

        // Relacionamento com Alunos
        [JsonIgnore]
        public ICollection<Aluno> Alunos { get; set; } = new List<Aluno>();
    }
}
