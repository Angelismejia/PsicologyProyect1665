using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PsychologyConsultation.Infrastructure.Data;
using PsychologyConsultation.Domain.Entities;

namespace PsychologyConsultation.Web.Controllers
{
    public class TratamientoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TratamientoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tratamiento/Index
        public IActionResult Index()
        {
            var tratamientos = _context.Tratamientos.ToList();
            return View(tratamientos);
        }

        // GET: Tratamiento/Details/5
        public IActionResult Details(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento == null) return NotFound();

            return View(tratamiento);
        }

        // GET: Tratamiento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tratamiento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tratamiento tratamiento)
        {
            if (ModelState.IsValid)
            {
                _context.Tratamientos.Add(tratamiento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tratamiento);
        }

        // GET: Tratamiento/Edit/5
        public IActionResult Edit(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento == null) return NotFound();

            return View(tratamiento);
        }

        // POST: Tratamiento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tratamiento tratamiento)
        {
            if (id != tratamiento.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var existingTratamiento = _context.Tratamientos.Find(id);
                if (existingTratamiento == null) return NotFound();

                existingTratamiento.Nombre = tratamiento.Nombre;
                existingTratamiento.Descripcion = tratamiento.Descripcion;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(tratamiento);
        }

        // GET: Tratamiento/Delete/5
        public IActionResult Delete(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento == null) return NotFound();

            return View(tratamiento);
        }

        // POST: Tratamiento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tratamiento = _context.Tratamientos.Find(id);
            if (tratamiento == null) return NotFound();

            _context.Tratamientos.Remove(tratamiento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

