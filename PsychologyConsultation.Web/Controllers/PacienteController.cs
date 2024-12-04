using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyConsultation.Domain.Entities;
using PsychologyConsultation.Infrastructure;
using PsychologyConsultation.Infrastructure.Data;

namespace PsychologyConsultation.Web.Controllers
{
    public class PacienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PacienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Listar todos los pacientes
        public async Task<IActionResult> Index()
        {
            var pacientes = await _context.Pacientes.ToListAsync();
            return View(pacientes);
        }

        // Detalles de un paciente específico
        public async Task<IActionResult> Details(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        // Crear un nuevo paciente (Formulario)
        public IActionResult Create()
        {
            return View();
        }

        // Crear un nuevo paciente (Guardar en BD)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Pacientes.Add(paciente);
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // Editar un paciente existente (Formulario)
        public async Task<IActionResult> Edit(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        // Editar un paciente existente (Guardar cambios)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Paciente paciente)
        {
            if (id != paciente.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paciente);
                    await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacienteExists(paciente.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(paciente);
        }

        // Eliminar un paciente existente (Formulario)
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null) return NotFound();
            return View(paciente);
        }

        // Eliminar un paciente existente (Confirmación)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }
    }
}
