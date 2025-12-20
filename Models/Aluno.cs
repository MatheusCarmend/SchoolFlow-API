namespace SchoolFlow.API.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public int TurmaId { get; set; }
        public Turma Turma { get; set; }
    }
}
