using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;
using PsychologyConsultation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Service
{
    public class PacienteService : IPacienteService
    {
        // Inicializar la lista de manera segura
        private readonly List<PacienteDto> _pacientes = new List<PacienteDto>();

        public async Task<IEnumerable<PacienteDto>> GetAllPacientesAsync()
        {
            // Siempre devolver una lista, incluso si está vacía
            return await Task.FromResult(_pacientes ?? new List<PacienteDto>());
        }

        public async Task<PacienteDto> GetPacienteByIdAsync(int id)
        {
            // Manejo seguro de búsqueda de paciente
            var paciente = _pacientes?.FirstOrDefault(p => p.Id == id);
            return await Task.FromResult(paciente);
        }

        public async Task<PacienteDto> AddPacienteAsync(PacienteDto pacienteDto)
        {
            // Validación de nulidad
            if (pacienteDto == null)
                throw new ArgumentNullException(nameof(pacienteDto), "El paciente no puede ser nulo");

            // Generación segura de ID
            pacienteDto.Id = (_pacientes?.Any() ?? false)
                ? (_pacientes?.Max(p => p.Id) ?? 0) + 1
                : 1;

            // Agregar paciente de manera segura
            _pacientes?.Add(pacienteDto);

            return await Task.FromResult(pacienteDto);
        }

        public async Task<PacienteDto> UpdatePacienteAsync(int id, PacienteDto pacienteDto)
        {
            // Validación de nulidad
            if (pacienteDto == null)
                throw new ArgumentNullException(nameof(pacienteDto), "El paciente no puede ser nulo");

            // Corrección para línea 26: Usar una verificación segura
            var existingPaciente = _pacientes.FirstOrDefault(p => p.Id == id);

            // Verificar si el paciente existe
            if (existingPaciente == null)
                return null;

            // Actualización segura de propiedades
            existingPaciente.Nombre = pacienteDto.Nombre ?? existingPaciente.Nombre;
            existingPaciente.Apellido = pacienteDto.Apellido ?? existingPaciente.Apellido;
            existingPaciente.FechaNacimiento = pacienteDto.FechaNacimiento;
            existingPaciente.Telefono = pacienteDto.Telefono ?? existingPaciente.Telefono;
            existingPaciente.Email = pacienteDto.Email ?? existingPaciente.Email;

            // Corrección para línea 57: Verificación null-coalescing para ConsultaIds
            existingPaciente.ConsultaIds = pacienteDto.ConsultaIds ?? existingPaciente.ConsultaIds ?? new List<int>();

            return await Task.FromResult(existingPaciente);
        }

        public async Task<bool> DeletePacienteAsync(int id)
        {
            // Búsqueda segura del paciente
            var paciente = _pacientes?.FirstOrDefault(p => p.Id == id);

            // Verificar si el paciente existe
            if (paciente == null)
                return false;

            // Eliminar paciente de manera segura
            bool removed = _pacientes?.Remove(paciente) ?? false;

            return await Task.FromResult(removed);
        }
    }
}