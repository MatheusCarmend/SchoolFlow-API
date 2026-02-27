using SchoolFlow.API.DTOs;
using SchoolFlow.API.Models;

namespace SchoolFlow.API.Services
{
    public interface IProfessorService
    {
        Task<List<Professor>> GetAllAsync();
        Task<Professor?> GetByIdAsync(int id);
        Task<Professor> CreateAsync(CreateProfessorDto dto);
        Task<bool> UpdateAsync(int id, CreateProfessorDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
