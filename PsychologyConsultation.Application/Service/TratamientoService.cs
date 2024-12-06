// Service/TratamientoService.cs
using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;
using PsychologyConsultation.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Service
{
    public class TratamientoService : ITratamientoService
    {
        // Simulamos una base de datos en memoria para este ejemplo
        private readonly List<TratamientoDto> _tratamientos = new List<TratamientoDto>();

        public async Task<IEnumerable<TratamientoDto>> GetAllTratamientosAsync()
        {
            return await Task.FromResult(_tratamientos.Where(t => t != null).ToList());
        }

        public async Task<TratamientoDto?> GetTratamientoByIdAsync(int id)
        {
            var tratamiento = _tratamientos.FirstOrDefault(t => t.Id == id);
            return await Task.FromResult(tratamiento); // Puede retornar null si no se encuentra
        }

        public async Task<TratamientoDto?> AddTratamientoAsync(TratamientoDto tratamientoDto)
        {
            if (tratamientoDto == null)
                return null; // Retornar null si el DTO recibido es nulo

            // Asignación de valores predeterminados en caso de null
            tratamientoDto.Nombre ??= string.Empty; // Si es null, asignamos una cadena vacía
            tratamientoDto.Descripcion ??= string.Empty; // Si es null, asignamos una cadena vacía
            tratamientoDto.DuracionDias ??= 0; // Si es null, asignamos 0

            tratamientoDto.Id = _tratamientos.Any() ? _tratamientos.Max(t => t.Id) + 1 : 1; // Generar un ID único

            _tratamientos.Add(tratamientoDto);
            return await Task.FromResult(tratamientoDto);
        }

        public async Task<TratamientoDto?> UpdateTratamientoAsync(int id, TratamientoDto tratamientoDto)
        {
            if (tratamientoDto == null)
                return null; // Retornar null si el DTO recibido es nulo

            var existingTratamiento = _tratamientos.FirstOrDefault(t => t.Id == id);
            if (existingTratamiento != null)
            {
                existingTratamiento.Nombre = tratamientoDto.Nombre ?? existingTratamiento.Nombre;
                existingTratamiento.Descripcion = tratamientoDto.Descripcion ?? existingTratamiento.Descripcion;
                existingTratamiento.DuracionDias = tratamientoDto.DuracionDias ?? existingTratamiento.DuracionDias;
                existingTratamiento.ConsultaId = tratamientoDto.ConsultaId ?? existingTratamiento.ConsultaId;
            }

            return await Task.FromResult(existingTratamiento);
        }

        public async Task<bool> DeleteTratamientoAsync(int id)
        {
            var tratamiento = _tratamientos.FirstOrDefault(t => t.Id == id);
            if (tratamiento != null)
            {
                _tratamientos.Remove(tratamiento);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}
