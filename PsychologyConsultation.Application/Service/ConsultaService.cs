// Service/ConsultaService.cs
using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;
using PsychologyConsultation.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Service
{
    public class ConsultaService : IConsultaService
    {
        // Simulamos una base de datos en memoria para este ejemplo
        private readonly List<ConsultaDto> _consultas = new List<ConsultaDto>();

        public async Task<IEnumerable<ConsultaDto>> GetAllConsultasAsync()
        {
            return await Task.FromResult(_consultas);
        }

        public async Task<ConsultaDto> GetConsultaByIdAsync(int id)
        {
            var consulta = _consultas.FirstOrDefault(c => c.Id == id);
            return await Task.FromResult(consulta);
        }

        public async Task<ConsultaDto> AddConsultaAsync(ConsultaDto consultaDto)
        {
            consultaDto.Id = _consultas.Max(c => c.Id ?? 0) + 1; // Generar un ID único
            _consultas.Add(consultaDto);
            return await Task.FromResult(consultaDto);
        }

        public async Task<ConsultaDto> UpdateConsultaAsync(int id, ConsultaDto consultaDto)
        {
            var existingConsulta = _consultas.FirstOrDefault(c => c.Id == id);
            if (existingConsulta != null)
            {
                existingConsulta.Fecha = consultaDto.Fecha;
                existingConsulta.Detalles = consultaDto.Detalles;
                existingConsulta.Estado = consultaDto.Estado;
                existingConsulta.PacienteId = consultaDto.PacienteId;
                existingConsulta.TratamientoIds = consultaDto.TratamientoIds;
            }
            return await Task.FromResult(existingConsulta);
        }

        public async Task<bool> DeleteConsultaAsync(int id)
        {
            var consulta = _consultas.FirstOrDefault(c => c.Id == id);
            if (consulta != null)
            {
                _consultas.Remove(consulta);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}
