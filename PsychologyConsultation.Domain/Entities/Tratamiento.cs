using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Domain.Entities
{
    public class Tratamiento
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? DuracionDias { get; set; }

        // Relación con Consulta
        public int? ConsultaId { get; set; }
        public Consulta? Consulta { get; set; }
    }
}
