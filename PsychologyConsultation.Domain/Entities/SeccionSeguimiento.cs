using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Domain.Entities
{
    public class SeccionSeguimiento
    {
        public int Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Observaciones { get; set; }
        public bool Completada { get; set; }

        // Relación con Tratamiento
        public int TratamientoId { get; set; }
        public Tratamiento? Tratamiento { get; set; } 
    }
}
