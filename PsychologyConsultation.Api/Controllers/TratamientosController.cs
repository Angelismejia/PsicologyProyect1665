// Controllers/TratamientoController.cs
using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TratamientoController : ControllerBase
    {
        private readonly ITratamientoService _tratamientoService;

        public TratamientoController(ITratamientoService tratamientoService)
        {
            _tratamientoService = tratamientoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tratamientos = await _tratamientoService.GetAllTratamientosAsync();
            return Ok(tratamientos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tratamiento = await _tratamientoService.GetTratamientoByIdAsync(id);
            if (tratamiento == null)
                return NotFound();
            return Ok(tratamiento);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TratamientoDto tratamientoDto)
        {
            if (tratamientoDto == null)
                return BadRequest();

            var tratamientoCreado = await _tratamientoService.AddTratamientoAsync(tratamientoDto);
            return CreatedAtAction(nameof(GetById), new { id = tratamientoCreado.Id }, tratamientoCreado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TratamientoDto tratamientoDto)
        {
            if (tratamientoDto == null)
                return BadRequest();

            var tratamientoActualizado = await _tratamientoService.UpdateTratamientoAsync(id, tratamientoDto);
            if (tratamientoActualizado == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _tratamientoService.DeleteTratamientoAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
