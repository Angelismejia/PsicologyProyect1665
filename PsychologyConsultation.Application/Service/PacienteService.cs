using PsychologyConsultation.Application.DTOs;

public class PacienteService : IPacienteService
{
    private readonly List<PacienteDto> _pacientes = new(); // Simulación de base de datos

    public async Task<IEnumerable<PacienteDto>> GetAllAsync()
    {
        return _pacientes;
    }

    public async Task<PacienteDto> GetByIdAsync(int id)
    {
        return _pacientes.FirstOrDefault(p => p.Id == id);
    }

    public async Task<PacienteDto> CreateAsync(PacienteDto pacienteDto)
    {
        pacienteDto.Id = _pacientes.Count + 1;
        _pacientes.Add(pacienteDto);
        return pacienteDto;
    }

    public async Task<PacienteDto> UpdateAsync(int id, PacienteDto pacienteDto)
    {
        var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
        if (paciente == null) return null;

        paciente.Nombre = pacienteDto.Nombre;
        paciente.Apellido = pacienteDto.Apellido;
        paciente.Telefono = pacienteDto.Telefono;
        paciente.Email = pacienteDto.Email;
        paciente.FechaNacimiento = pacienteDto.FechaNacimiento;

        return paciente;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var paciente = _pacientes.FirstOrDefault(p => p.Id == id);
        if (paciente == null) return false;

        _pacientes.Remove(paciente);
        return true;
    }
}
