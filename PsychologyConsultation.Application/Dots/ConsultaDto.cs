using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.DTOs
{
    public class ConsultaDto
    {
        public int? Id { get; set; }
        public DateTime? FechaConsulta { get; set; }
        public string? Descripcion { get; set; }
        public string? Diagnostico { get; set; }
        public int PacienteId { get; set; }
    }

}
