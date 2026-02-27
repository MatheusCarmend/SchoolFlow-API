namespace SchoolFlow.API.Responses
{
    public class ValidationErrorResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = "Erro de validação";
        public Dictionary<string, string[]> Errors { get; set; }
    }
}
