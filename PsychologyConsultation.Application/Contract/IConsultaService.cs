// Contract/IConsultaService.cs
using PsychologyConsultation.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.Contract
{
    public interface IConsultaService
    {
        Task<IEnumerable<ConsultaDto>> GetAllConsultasAsync();
        Task<ConsultaDto> GetConsultaByIdAsync(int id);
        Task<ConsultaDto> AddConsultaAsync(ConsultaDto consultaDto);
        Task<ConsultaDto> UpdateConsultaAsync(int id, ConsultaDto consultaDto);
        Task<bool> DeleteConsultaAsync(int id);
    }
}
