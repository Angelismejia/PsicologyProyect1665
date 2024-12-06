// Dtos/ConsultaDto.cs
using System;
using System.Collections.Generic;

namespace PsychologyConsultation.Application.DTOs
{
    public class ConsultaDto
    {
        public int? Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Detalles { get; set; }
        public string? Estado { get; set; } // Ejemplo: "Pendiente", "Completada"
        public int? PacienteId { get; set; }
        public ICollection<int> TratamientoIds { get; set; } = new List<int>();
    }
}
