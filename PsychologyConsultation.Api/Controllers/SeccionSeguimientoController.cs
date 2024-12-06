using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.DTOs;
using PsychologyConsultation.Application.Interfaces;
using System.Threading.Tasks;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SesionesSeguimientoController : ControllerBase
    {
        private readonly ISesionSeguimientoService _sesionSeguimientoService;

        // Constructor con inyección de dependencias
        public SesionesSeguimientoController(ISesionSeguimientoService sesionSeguimientoService)
        {
            _sesionSeguimientoService = sesionSeguimientoService;
        }

        // Obtener todas las sesiones de seguimiento
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sesiones = await _sesionSeguimientoService.GetAllSesionesAsync();
            return Ok(sesiones);
        }

        // Obtener una sesión de seguimiento por su Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sesion = await _sesionSeguimientoService.GetSesionByIdAsync(id);
            if (sesion == null)
                return NotFound(); // Si no se encuentra, devuelve NotFound

            return Ok(sesion);
        }

        // Crear una nueva sesión de seguimiento
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SesionSeguimientoDto sesionDto)
        {
            if (sesionDto == null)
                return BadRequest(); // Verifica que el cuerpo no esté vacío

            var sesionCreada = await _sesionSeguimientoService.AddSesionAsync(sesionDto);

            // Devuelve el resultado creado con el código HTTP 201
            return CreatedAtAction(nameof(GetById), new { id = sesionCreada.Id }, sesionCreada);
        }

        // Actualizar una sesión de seguimiento
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SesionSeguimientoDto sesionDto)
        {
            if (sesionDto == null)
                return BadRequest();

            var sesionActualizada = await _sesionSeguimientoService.UpdateSesionAsync(id, sesionDto);
            if (sesionActualizada == null)
                return NotFound(); // Si no existe la sesión, devuelve NotFound

            return NoContent(); // Si todo va bien, devuelve NoContent
        }

        // Eliminar una sesión de seguimiento
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _sesionSeguimientoService.DeleteSesionAsync(id);
            if (!result)
                return NotFound(); // Si no se encuentra, devuelve NotFound

            return NoContent(); // Si se eliminó correctamente, devuelve NoContent
        }
    }
}
