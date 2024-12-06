// Controllers/ConsultaController.cs
using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var consultas = await _consultaService.GetAllConsultasAsync();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            if (consulta == null)
                return NotFound();
            return Ok(consulta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ConsultaDto consultaDto)
        {
            if (consultaDto == null)
                return BadRequest();

            var consultaCreada = await _consultaService.AddConsultaAsync(consultaDto);
            return CreatedAtAction(nameof(GetById), new { id = consultaCreada.Id }, consultaCreada);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ConsultaDto consultaDto)
        {
            if (consultaDto == null)
                return BadRequest();

            var consultaActualizada = await _consultaService.UpdateConsultaAsync(id, consultaDto);
            if (consultaActualizada == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _consultaService.DeleteConsultaAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
