using PsychologyConsultation.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Interfaces
{
    public interface ISesionSeguimientoService
    {
        Task<IEnumerable<SesionSeguimientoDto>> GetAllSesionesAsync();
        Task<SesionSeguimientoDto> GetSesionByIdAsync(int id);
        Task<SesionSeguimientoDto> AddSesionAsync(SesionSeguimientoDto sesionDto);
        Task<SesionSeguimientoDto> UpdateSesionAsync(int id, SesionSeguimientoDto sesionDto);
        Task<bool> DeleteSesionAsync(int id);
    }
}
