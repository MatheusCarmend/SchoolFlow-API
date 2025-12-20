namespace SchoolFlow.API.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Nivel { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public List<Aluno> Alunos { get; set; }
    }
}
