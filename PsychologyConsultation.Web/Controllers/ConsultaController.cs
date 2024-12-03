using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyConsultation.Domain.Entities;
using PsychologyConsultation.Infrastructure.Data;
using System.Linq;

namespace PsychologyConsultation.Web.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Consulta
        public IActionResult Index()
        {
            var consultas = _context.Consultas
                .Include(c => c.Paciente) // Aseguramos que se cargue el paciente relacionado
                .ToList();
            return View(consultas);
        }

        // GET: Consulta/Details/5
        public IActionResult Details(int id)
        {
            var consulta = _context.Consultas
                .Include(c => c.Paciente) // Cargamos el paciente relacionado
                .FirstOrDefault(c => c.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            ViewBag.Pacientes = _context.Pacientes.ToList(); // Cargar lista de pacientes
            return View();
        }

        // POST: Consulta/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Fecha,Detalles,Estado,PacienteId")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Pacientes = _context.Pacientes.ToList(); // Cargar lista de pacientes nuevamente en caso de error
            return View(consulta);
        }

             // GET: Consulta/Edit/5
        public IActionResult Edit(int id)
        {
            var consulta = _context.Consultas
                .Include(c => c.Paciente) // Cargamos el paciente relacionado
                .FirstOrDefault(c => c.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            ViewBag.Pacientes = _context.Pacientes.ToList(); // Cargar lista de pacientes
            return View(consulta);
        }

        // POST: Consulta/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Fecha,Detalles,Estado,PacienteId")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Consultas.Any(c => c.Id == consulta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Pacientes = _context.Pacientes.ToList(); // Cargar lista de pacientes nuevamente en caso de error
            return View(consulta);
        }


        // GET: Consulta/Delete/5
        public IActionResult Delete(int id)
        {
            var consulta = _context.Consultas
                .Include(c => c.Paciente) // Cargamos el paciente relacionado
                .FirstOrDefault(c => c.Id == id);

            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var consulta = _context.Consultas.Find(id);
            if (consulta != null)
            {
                _context.Consultas.Remove(consulta);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
