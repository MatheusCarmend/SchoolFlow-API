using Microsoft.AspNetCore.Mvc;
using SchoolFlow.API.DTOs;
using SchoolFlow.API.Models;
using SchoolFlow.API.Responses;
using SchoolFlow.API.Services;

namespace SchoolFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private readonly IProfessorService _service;

        public ProfessoresController(IProfessorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfessores()
        {
            var professores = await _service.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<Professor>>(true, "Lista de professores", professores));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessor(int id)
        {
            var professor = await _service.GetByIdAsync(id);
            if (professor == null)
                return NotFound(new ApiResponse<object>(false, "Professor não encontrado", null));

            return Ok(new ApiResponse<Professor>(true, "Professor encontrado", professor));
        }

        [HttpPost]
        public async Task<IActionResult> PostProfessor([FromBody] CreateProfessorDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var professor = await _service.CreateAsync(dto);

            return CreatedAtAction(nameof(GetProfessor),
                new { id = professor.Id },
                new ApiResponse<Professor>(true, "Professor criado com sucesso", professor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessor(int id, CreateProfessorDto dto)
        {
            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound(new ApiResponse<object>(false, "Professor não encontrado", null));

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound(new ApiResponse<object>(false, "Professor não encontrado", null));

            return NoContent();
        }
    }
}
