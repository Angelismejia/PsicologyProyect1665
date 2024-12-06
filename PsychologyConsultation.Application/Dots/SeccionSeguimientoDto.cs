using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.DTOs
{
    public class SesionSeguimientoDto
    {
        public int Id { get; set; }
        public int TratamientoId { get; set; }
        public DateTime FechaSesion { get; set; }
        public string? Observaciones { get; set; }
        public string? EstadoPaciente { get; set; }
    }
}
