namespace SchoolFlow.API.DTOs
{
    public class UpdateTurmaDto
    {
        public string Nome { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Periodo { get; set; } = string.Empty;
        public bool Ativa { get; set; }
        public int ProfessorId { get; set; }
    }
}

