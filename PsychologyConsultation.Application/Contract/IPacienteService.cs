using PsychologyConsultation.Application.DTOs;

public interface IPacienteService
{
    Task<IEnumerable<PacienteDto>> GetAllAsync();
    Task<PacienteDto> GetByIdAsync(int id);
    Task<PacienteDto> CreateAsync(PacienteDto pacienteDto);
    Task<PacienteDto> UpdateAsync(int id, PacienteDto pacienteDto);
    Task<bool> DeleteAsync(int id);
}
