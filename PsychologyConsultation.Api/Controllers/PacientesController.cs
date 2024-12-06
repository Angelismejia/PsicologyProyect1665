// Controllers/PacienteController.cs
using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _pacienteService.GetAllPacientesAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
                return NotFound();
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PacienteDto pacienteDto)
        {
            if (pacienteDto == null)
                return BadRequest();

            var pacienteCreado = await _pacienteService.AddPacienteAsync(pacienteDto);
            return CreatedAtAction(nameof(GetById), new { id = pacienteCreado.Id }, pacienteCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PacienteDto pacienteDto)
        {
            if (pacienteDto == null)
                return BadRequest();

            var pacienteActualizado = await _pacienteService.UpdatePacienteAsync(id, pacienteDto);
            if (pacienteActualizado == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pacienteService.DeletePacienteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
