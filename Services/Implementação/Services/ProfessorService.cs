using Microsoft.EntityFrameworkCore;
using SchoolFlow.API.Data;
using SchoolFlow.API.DTOs;
using SchoolFlow.API.Models;

namespace SchoolFlow.API.Services
{
    public class ProfessorService : IProfessorService
    {
        private readonly SchoolFlowContext _context;

        public ProfessorService(SchoolFlowContext context)
        {
            _context = context;
        }

        public async Task<List<Professor>> GetAllAsync()
        {
            return await _context.Professores.ToListAsync();
        }

        public async Task<Professor?> GetByIdAsync(int id)
        {
            return await _context.Professores.FindAsync(id);
        }

        public async Task<Professor> CreateAsync(CreateProfessorDto dto)
        {
            var professor = new Professor
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Especialidade = dto.Especialidade,
                Telefone = dto.Telefone
            };

            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();

            return professor;
        }

        public async Task<bool> UpdateAsync(int id, CreateProfessorDto dto)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
                return false;

            professor.Nome = dto.Nome;
            professor.Email = dto.Email;
            professor.Especialidade = dto.Especialidade;
            professor.Telefone = dto.Telefone;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
                return false;

            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
