using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyConsultation.Domain.Entities;
using PsychologyConsultation.Infrastructure.Data;
using System.Threading.Tasks;

namespace PsychologyConsultation.Web.Controllers
{
    [Route("SeccionSeguimiento")]
    public class SeccionSeguimientoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SeccionSeguimientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Acción para listar todas las secciones de seguimiento
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var secciones = await _context.SeccionesSeguimiento.ToListAsync();
            return View(secciones);
        }

        // Acción para mostrar el formulario de creación
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar el formulario de creación
        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SeccionSeguimiento seccion)
        {
            if (ModelState.IsValid)
            {
                _context.SeccionesSeguimiento.Add(seccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(seccion);
        }

        // Acción para mostrar el formulario de edición
        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var seccion = await _context.SeccionesSeguimiento.FindAsync(id);

            if (seccion == null)
            {
                return NotFound();
            }

            return View(seccion);
        }

        // Acción para procesar el formulario de edición
        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SeccionSeguimiento seccion)
        {
            if (id != seccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.SeccionesSeguimiento.Update(seccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _context.SeccionesSeguimiento.AnyAsync(s => s.Id == id))
                    {
                        return NotFound();
                    }

                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(seccion);
        }

        // Acción para mostrar la confirmación de eliminación
        [HttpGet("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var seccion = await _context.SeccionesSeguimiento.FindAsync(id);

            if (seccion == null)
            {
                return NotFound();
            }

            return View(seccion);
        }

        // Acción para procesar la eliminación
        [HttpPost("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seccion = await _context.SeccionesSeguimiento.FindAsync(id);

            if (seccion != null)
            {
                _context.SeccionesSeguimiento.Remove(seccion);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
