using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Domain.Entities
{
    public class Paciente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }

        // Relación con Consultas
        public ICollection<Consulta> Consultas { get; set; } = new List<Consulta>(); // Inicialización de la colección
    }
}
