using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFlow.API.Data;
using SchoolFlow.API.DTOs;
using SchoolFlow.API.Models;

namespace SchoolFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private readonly SchoolFlowContext _context;

        public ProfessoresController(SchoolFlowContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessores()
        {
            return await _context.Professores.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _context.Professores.FindAsync(id);

            if (professor == null)
                return NotFound();

            return professor;
        }
        [HttpPost]
        public async Task<IActionResult> PostProfessor(CreateProfessorDto dto)
        {
            var professor = new Professor
            {
                Nome = dto.Nome,
                Especialidade = dto.Especialidade,
                Email = dto.Email,
                Telefone = dto.Telefone
            };

            _context.Professores.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, CreateProfessorDto dto)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
                return NotFound();

            professor.Nome = dto.Nome;
            professor.Email = dto.Email;
            professor.Especialidade = dto.Especialidade;
            professor.Telefone = dto.Telefone;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _context.Professores.FindAsync(id);
            if (professor == null)
                return NotFound();

            _context.Professores.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }


    }
}
