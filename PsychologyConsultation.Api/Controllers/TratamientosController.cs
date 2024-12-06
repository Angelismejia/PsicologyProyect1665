using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.DTOs;
using PsychologyConsultation.Application.Interfaces;
using System.Threading.Tasks;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientosController : ControllerBase
    {
        private readonly ITratamientoService _tratamientoService;

        // Constructor con inyección de dependencias
        public TratamientosController(ITratamientoService tratamientoService)
        {
            _tratamientoService = tratamientoService;
        }

        // Obtener todos los tratamientos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tratamientos = await _tratamientoService.GetAllTratamientosAsync();
            return Ok(tratamientos);
        }

        // Obtener un tratamiento por su Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tratamiento = await _tratamientoService.GetTratamientoByIdAsync(id);
            if (tratamiento == null)
                return NotFound(); // Si no se encuentra el tratamiento, devuelve NotFound

            return Ok(tratamiento);
        }

        // Crear un nuevo tratamiento
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TratamientoDto tratamientoDto)
        {
            if (tratamientoDto == null)
                return BadRequest(); // Verifica que el cuerpo no esté vacío

            var tratamientoCreado = await _tratamientoService.AddTratamientoAsync(tratamientoDto);

            // Devuelve el resultado creado con el código HTTP 201
            return CreatedAtAction(nameof(GetById), new { id = tratamientoCreado.Id }, tratamientoCreado);
        }

        // Actualizar un tratamiento
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TratamientoDto tratamientoDto)
        {
            if (tratamientoDto == null)
                return BadRequest();

            var tratamientoActualizado = await _tratamientoService.UpdateTratamientoAsync(id, tratamientoDto);
            if (tratamientoActualizado == null)
                return NotFound(); // Si no existe el tratamiento, devuelve NotFound

            return NoContent(); // Si todo va bien, devuelve NoContent
        }

        // Eliminar un tratamiento
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tratamientoService.DeleteTratamientoAsync(id);
            if (!result)
                return NotFound(); // Si no se encuentra el tratamiento, devuelve NotFound

            return NoContent(); // Si se eliminó correctamente, devuelve NoContent
        }
    }
}
