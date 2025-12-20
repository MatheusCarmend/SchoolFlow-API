namespace SchoolFlow.API.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
