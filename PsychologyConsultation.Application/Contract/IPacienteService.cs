// Contract/IPacienteService.cs
using PsychologyConsultation.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Contract
{
    public interface IPacienteService
    {
        Task<IEnumerable<PacienteDto>> GetAllPacientesAsync();
        Task<PacienteDto> GetPacienteByIdAsync(int id);
        Task<PacienteDto> AddPacienteAsync(PacienteDto pacienteDto);
        Task<PacienteDto> UpdatePacienteAsync(int id, PacienteDto pacienteDto);
        Task<bool> DeletePacienteAsync(int id);
    }
}
