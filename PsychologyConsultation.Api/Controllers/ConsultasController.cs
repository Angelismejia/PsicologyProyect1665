using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Application.DTOs;
using PsychologyConsultation.Application.Interfaces;

namespace PsychologyConsultation.Api.Controllers
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
        public async Task<ActionResult<IEnumerable<ConsultaDto>>> GetAllConsultas()
        {
            var consultas = await _consultaService.GetAllConsultasAsync();
            return Ok(consultas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ConsultaDto>> GetConsultaById(int id)
        {
            var consulta = await _consultaService.GetConsultaByIdAsync(id);
            if (consulta == null)
                return NotFound();

            return Ok(consulta);
        }

        [HttpPost]
        public async Task<ActionResult<ConsultaDto>> CreateConsulta(ConsultaDto consultaDto)
        {
            var consulta = await _consultaService.AddConsultaAsync(consultaDto);
            return CreatedAtAction(nameof(GetConsultaById), new { id = consulta.Id }, consulta);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ConsultaDto>> UpdateConsulta(int id, ConsultaDto consultaDto)
        {
            var updatedConsulta = await _consultaService.UpdateConsultaAsync(id, consultaDto);
            if (updatedConsulta == null)
                return NotFound();

            return Ok(updatedConsulta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsulta(int id)
        {
            var success = await _consultaService.DeleteConsultaAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
