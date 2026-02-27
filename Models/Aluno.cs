namespace SchoolFlow.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; } = null!;
        public bool Ativo { get; set; } = true;
        // Relacionamento com Turma
        public int TurmaId { get; set; }
        public Turma Turma { get; set; } = null!;
    }
}
