using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.DTOs
{
    public class TratamientoDto
    {
        public int Id { get; set; }
        public int ConsultaId { get; set; }
        public string? NombreTratamiento { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool EstaActivo { get; set; }
    }
}
