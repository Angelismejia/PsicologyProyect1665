// Dtos/SeccionSeguimientoDto.cs
using System;

namespace PsychologyConsultation.Application.DTOs
{
    public class SeccionSeguimientoDto
    {
        public int? Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Observaciones { get; set; }
        public bool Completada { get; set; }
        public int TratamientoId { get; set; }
    }
}
