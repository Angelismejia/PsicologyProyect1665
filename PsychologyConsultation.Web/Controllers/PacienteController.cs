using Microsoft.AspNetCore.Mvc;
using PsychologyConsultation.Domain.Entities;

namespace PsychologyConsultation.Web.Controllers
{
    public class PacienteController : Controller
    {
        private static List<Paciente> Pacientes = new List<Paciente>
        {
            new Paciente { Id = 1, Nombre = "Juan", Apellido = "Pérez", FechaNacimiento = new DateTime(1990, 5, 20), Telefono = "123456789", Email = "juan.perez@example.com" },
            new Paciente { Id = 2, Nombre = "Ana", Apellido = "Gómez", FechaNacimiento = new DateTime(1985, 3, 15), Telefono = "987654321", Email = "ana.gomez@example.com" }
        };

        public IActionResult Index()
        {
            return View(Pacientes);
        }

        public IActionResult Details(int id)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Paciente paciente)
        {
            paciente.Id = Pacientes.Count + 1;
            Pacientes.Add(paciente);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost]
        public IActionResult Edit(Paciente paciente)
        {
            var existing = Pacientes.FirstOrDefault(p => p.Id == paciente.Id);
            if (existing == null) return NotFound();

            existing.Nombre = paciente.Nombre;
            existing.Apellido = paciente.Apellido;
            existing.FechaNacimiento = paciente.FechaNacimiento;
            existing.Telefono = paciente.Telefono;
            existing.Email = paciente.Email;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var paciente = Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null) Pacientes.Remove(paciente);
            return RedirectToAction("Index");
        }
    }
}
