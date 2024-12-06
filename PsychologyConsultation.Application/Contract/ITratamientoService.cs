using PsychologyConsultation.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Interfaces
{
    public interface ITratamientoService
    {
        Task<IEnumerable<TratamientoDto>> GetAllTratamientosAsync();
        Task<TratamientoDto> GetTratamientoByIdAsync(int id);
        Task<TratamientoDto> AddTratamientoAsync(TratamientoDto tratamientoDto);
        Task<TratamientoDto> UpdateTratamientoAsync(int id, TratamientoDto tratamientoDto);
        Task<bool> DeleteTratamientoAsync(int id);
    }
}
