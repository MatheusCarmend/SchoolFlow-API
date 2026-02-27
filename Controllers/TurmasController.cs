using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFlow.API.Data;
using SchoolFlow.API.DTOs;
using SchoolFlow.API.DTOs.Responses;
using SchoolFlow.API.Models;
using SchoolFlow.API.Responses;

namespace SchoolFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurmasController : ControllerBase
    {
        private readonly SchoolFlowContext _context;

        public TurmasController(SchoolFlowContext context)
        {
            _context = context;
        }

        // GET: api/Turmas
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var turmas = await _context.Turmas
                .Select(t => new TurmaResponseDto
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    Ano = t.Ano,
                    Periodo = t.Periodo,
                    ProfessorId = t.ProfessorId
                })
                .ToListAsync();

            return Ok(new ApiResponse<IEnumerable<TurmaResponseDto>>(true,"Lista de turmas",turmas));
        }


        // GET: api/Turmas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var turma = await _context.Turmas
                .Where(t => t.Id == id)
                .Select(t => new TurmaResponseDto
                {
                    Id = t.Id,
                    Nome = t.Nome,
                    Ano = t.Ano,
                    Periodo = t.Periodo,
                    ProfessorId = t.ProfessorId
                })
                .FirstOrDefaultAsync();

            if (turma == null)
                return NotFound(new ApiResponse<object>(false, "Turma não encontrada", null));

            return Ok(new ApiResponse<TurmaResponseDto>(true,"Turma encontrada",turma));
        }


        // POST: api/Turmas
        [HttpPost]
        public async Task<IActionResult> Create(CreateTurmaDto dto)
        {
            var professor = await _context.Professores.FindAsync(dto.ProfessorId);
            if (professor == null)
                return BadRequest(new ApiResponse<object>(false, "Professor inválido", null));

            var turma = new Turma
            {
                Nome = dto.Nome,
                Ano = dto.Ano,
                Periodo = dto.Periodo,
                ProfessorId = dto.ProfessorId
            };

            _context.Turmas.Add(turma);
            await _context.SaveChangesAsync();

            var response = new TurmaResponseDto
            {
                Id = turma.Id,
                Nome = turma.Nome,
                Ano = turma.Ano,
                Periodo = turma.Periodo,
                ProfessorId = turma.ProfessorId
            };

            return CreatedAtAction(nameof(GetById),new { id = turma.Id },new ApiResponse<TurmaResponseDto>(true,"Turma criada com sucesso",response));
        }

        // PUT: api/Turmas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTurmaDto dto)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
                return NotFound(new ApiResponse<object>(false, "Turma não encontrada", null));

            var professor = await _context.Professores.FindAsync(dto.ProfessorId);
            if (professor == null)
                return BadRequest(new ApiResponse<object>(false, "Professor inválido", null));

            turma.Nome = dto.Nome;
            turma.Ano = dto.Ano;
            turma.Periodo = dto.Periodo;
            turma.Ativa = dto.Ativa;
            turma.ProfessorId = dto.ProfessorId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Turmas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var turma = await _context.Turmas.FindAsync(id);
            if (turma == null)
                return NotFound(new ApiResponse<object>(false, "Turma não encontrada", null));

            _context.Turmas.Remove(turma);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

