// Contract/ISeccionSeguimientoService.cs
using PsychologyConsultation.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Contract
{
    public interface ISeccionSeguimientoService
    {
        Task<IEnumerable<SeccionSeguimientoDto>> GetAllSesionSeguimientoAsync();
        Task<SeccionSeguimientoDto> GetSesionSeguimientoByIdAsync(int id);
        Task<SeccionSeguimientoDto> AddSesionSeguimientoAsync(SeccionSeguimientoDto sesionSeguimientoDto);
        Task<SeccionSeguimientoDto> UpdateSesionSeguimientoAsync(int id, SeccionSeguimientoDto sesionSeguimientoDto);
        Task<bool> DeleteSesionSeguimientoAsync(int id);
    }
}
