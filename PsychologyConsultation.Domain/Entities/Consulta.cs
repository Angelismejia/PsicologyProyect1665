using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Domain.Entities
{
    public class Consulta
    {
        public int? Id { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Detalles { get; set; }
        public string? Estado { get; set; } // Ejemplo: "Pendiente", "Completada"

        // Relación con Paciente
        public int? PacienteId { get; set; }
        public Paciente? Paciente { get; set; }

        // Relación con Tratamiento
        public ICollection<Tratamiento> Tratamientos { get; set; } = new List<Tratamiento>();
    }
}
