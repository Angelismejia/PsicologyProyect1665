// Controllers/SeccionSeguimientoController.cs
using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionSeguimientoController : ControllerBase
    {
        private readonly ISeccionSeguimientoService _seccionSeguimientoService;

        public SeccionSeguimientoController(ISeccionSeguimientoService seccionSeguimientoService)
        {
            _seccionSeguimientoService = seccionSeguimientoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sesiones = await _seccionSeguimientoService.GetAllSesionSeguimientoAsync();
            return Ok(sesiones);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sesion = await _seccionSeguimientoService.GetSesionSeguimientoByIdAsync(id);
            if (sesion == null)
                return NotFound();
            return Ok(sesion);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SeccionSeguimientoDto seccionSeguimientoDto)
        {
            if (seccionSeguimientoDto == null)
                return BadRequest();

            var sesionCreada = await _seccionSeguimientoService.AddSesionSeguimientoAsync(seccionSeguimientoDto);
            return CreatedAtAction(nameof(GetById), new { id = sesionCreada.Id }, sesionCreada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SeccionSeguimientoDto seccionSeguimientoDto)
        {
            if (seccionSeguimientoDto == null)
                return BadRequest();

            var sesionActualizada = await _seccionSeguimientoService.UpdateSesionSeguimientoAsync(id, seccionSeguimientoDto);
            if (sesionActualizada == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _seccionSeguimientoService.DeleteSesionSeguimientoAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
