using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolFlow.API.Data;
using SchoolFlow.API.DTOs;
using SchoolFlow.API.Models;
using SchoolFlow.API.Responses;

namespace SchoolFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly SchoolFlowContext _context;

        public AlunosController(SchoolFlowContext context)
        {
            _context = context;
        }

        // GET: api/alunos ativos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var alunos = await _context.Alunos
                .Where(a => a.Ativo)
                .Include(a => a.Turma)
                .ToListAsync();

            return Ok(new ApiResponse<object>(true, "Alunos ativos", alunos));
        }

        // GET: api/alunos inativos
        [HttpGet("inativos")]
        public async Task<IActionResult> GetInativos()
        {
            var alunos = await _context.Alunos
                .Where(a => !a.Ativo)
                .Include(a => a.Turma)
                .ToListAsync();

            return Ok(new ApiResponse<IEnumerable<Aluno>>(true, "Alunos desativados", alunos));
        }

        // GET: api/alunos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var aluno = await _context.Alunos
                .Include(a => a.Turma)
                .FirstOrDefaultAsync(a => a.Id == id && a.Ativo);

            if (aluno == null)
                return NotFound(new ApiResponse<object>(false, "Aluno não encontrado", null));

            return Ok(new ApiResponse<object>(true, "Aluno encontrado", aluno));
        }

        // POST: api/alunos
        [HttpPost]
        public async Task<IActionResult> Create(CreateAlunoDto dto)
        {
            var turma = await _context.Turmas.FindAsync(dto.TurmaId);
            if (turma == null)
                return BadRequest(new ApiResponse<object>(false, "Turma inválida", null));

            var emailExiste = await _context.Alunos
                .AnyAsync(a => a.Email == dto.Email);

            if (emailExiste)
                return BadRequest(new ApiResponse<object>(false, "Email já cadastrado", null));

            var aluno = new Aluno
            {
                Nome = dto.Nome,
                Email = dto.Email,
                DataNascimento = dto.DataNascimento,
                Telefone = dto.Telefone,
                TurmaId = dto.TurmaId,
                Ativo = true
            };

            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = aluno.Id },
                new ApiResponse<Aluno>(true, "Aluno criado com sucesso", aluno));
        }

        // DELETE lógico (desativar)
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deactivate(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound(new ApiResponse<object>(false, "Aluno não encontrado", null));

            aluno.Ativo = false;
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<object>(true, "Aluno desativado", null));
        }

        // PATCH: retornar alunos desativados
        [HttpPatch("{id}/reativar")]
        public async Task<IActionResult> Reativar(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound(new ApiResponse<object>(false, "Aluno não encontrado", null));

            aluno.Ativo = true;
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<object>(true, "Aluno reativado com sucesso", null));
        }
    }
}

