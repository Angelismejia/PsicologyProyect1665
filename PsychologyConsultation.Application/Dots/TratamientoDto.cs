// Dtos/TratamientoDto.cs
using System;

namespace PsychologyConsultation.Application.DTOs
{
    public class TratamientoDto
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? DuracionDias { get; set; }
        public int? ConsultaId { get; set; }
    }
}
