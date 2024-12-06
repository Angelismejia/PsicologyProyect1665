using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Service
{
    public class SeccionSeguimientoService : ISeccionSeguimientoService
    {
        private readonly List<SeccionSeguimientoDto> _sesionesSeguimiento = new List<SeccionSeguimientoDto>(); // Simulación de almacenamiento en memoria

        public async Task<IEnumerable<SeccionSeguimientoDto>> GetAllSesionSeguimientoAsync()
        {
            return await Task.FromResult(_sesionesSeguimiento);
        }

        public async Task<SeccionSeguimientoDto> GetSesionSeguimientoByIdAsync(int id)
        {
            var sesion = _sesionesSeguimiento.FirstOrDefault(s => s.Id == id);
            if (sesion == null)
            {
                throw new KeyNotFoundException($"Sección de seguimiento con id {id} no encontrada."); // Handle null with exception
            }
            return await Task.FromResult(sesion);
        }

        public async Task<SeccionSeguimientoDto> AddSesionSeguimientoAsync(SeccionSeguimientoDto sesionSeguimientoDto)
        {
            if (sesionSeguimientoDto == null)
            {
                throw new ArgumentNullException(nameof(sesionSeguimientoDto)); // Ensure sesionSeguimientoDto is not null
            }

            sesionSeguimientoDto.Id = _sesionesSeguimiento.Any() ? (_sesionesSeguimiento.Max(s => s.Id ?? 0) + 1) : 1; // Ensure ID is assigned correctly
            _sesionesSeguimiento.Add(sesionSeguimientoDto);
            return await Task.FromResult(sesionSeguimientoDto);
        }

        public async Task<SeccionSeguimientoDto> UpdateSesionSeguimientoAsync(int id, SeccionSeguimientoDto sesionSeguimientoDto)
        {
            if (sesionSeguimientoDto == null)
            {
                throw new ArgumentNullException(nameof(sesionSeguimientoDto)); // Ensure sesionSeguimientoDto is not null
            }

            var existingSesion = _sesionesSeguimiento.FirstOrDefault(s => s.Id == id);
            if (existingSesion == null)
            {
                throw new KeyNotFoundException($"Sección de seguimiento con id {id} no encontrada."); // Handle null with exception
            }

            existingSesion.Fecha = sesionSeguimientoDto.Fecha;
            existingSesion.Observaciones = sesionSeguimientoDto.Observaciones;
            existingSesion.Completada = sesionSeguimientoDto.Completada;
            existingSesion.TratamientoId = sesionSeguimientoDto.TratamientoId;

            return await Task.FromResult(existingSesion);
        }

        public async Task<bool> DeleteSesionSeguimientoAsync(int id)
        {
            var sesion = _sesionesSeguimiento.FirstOrDefault(s => s.Id == id);
            if (sesion == null)
            {
                return await Task.FromResult(false); // Return false if sesion is not found
            }

            _sesionesSeguimiento.Remove(sesion);
            return await Task.FromResult(true);
        }
    }
}
