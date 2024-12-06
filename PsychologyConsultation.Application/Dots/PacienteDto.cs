// Dtos/PacienteDto.cs
using System;
using System.Collections.Generic;

namespace PsychologyConsultation.Application.DTOs
{
    public class PacienteDto
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public ICollection<int> ConsultaIds { get; set; } = new List<int>(); // IDs de las consultas
    }
}
