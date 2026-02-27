namespace SchoolFlow.API.DTOs.Responses
{
    public class TurmaResponseDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Periodo { get; set; } = string.Empty;
        public int ProfessorId { get; set; }
    }
}