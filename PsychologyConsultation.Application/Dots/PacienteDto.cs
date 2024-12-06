using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologyConsultation.Application.DTOs
{
    public class PacienteDto
    {
        
            public int? Id { get; set; }
            public string? Nombre { get; set; }
            public string? Apellido { get; set; }
            public string? Telefono { get; set; }
            public string? Email { get; set; }
            public DateTime FechaNacimiento { get; set; }
        
    }

}

