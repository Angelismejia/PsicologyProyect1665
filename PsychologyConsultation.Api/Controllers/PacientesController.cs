using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.DTOs;
using PsychologyConsultation.Application.Interfaces;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        // Constructor con inyección de dependencias
        public PacientesController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        // Obtener todos los pacientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pacientes = await _pacienteService.GetAllPacientesAsync();
            return Ok(pacientes);
        }

        // Obtener un paciente por su Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _pacienteService.GetPacienteByIdAsync(id);
            if (paciente == null)
                return NotFound();  // Si no lo encuentra, devuelve NotFound
            return Ok(paciente);
        }

        // Crear un nuevo paciente
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PacienteDto pacienteDto)
        {
            if (pacienteDto == null)
                return BadRequest();  // Verifica que el cuerpo no esté vacío

            // Llamar al servicio para crear el paciente
            var pacienteCreado = await _pacienteService.CreatePacienteAsync(pacienteDto);

            // Devuelve el resultado creado con el código HTTP 201
            return CreatedAtAction(nameof(GetById), new { id = pacienteCreado.Id }, pacienteCreado);
        }

        // Actualizar un paciente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PacienteDto pacienteDto)
        {
            if (pacienteDto == null)
                return BadRequest();

            var pacienteActualizado = await _pacienteService.UpdatePacienteAsync(id, pacienteDto);
            if (pacienteActualizado == null)
                return NotFound();  // Si no existe el paciente, devuelve NotFound

            return NoContent();  // Si todo va bien, devuelve NoContent
        }

        // Eliminar un paciente
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _pacienteService.DeletePacienteAsync(id);
            if (!result)
                return NotFound();  // Si no se encuentra, devuelve NotFound

            return NoContent();  // Si se eliminó correctamente, devuelve NoContent
        }
    }
}
