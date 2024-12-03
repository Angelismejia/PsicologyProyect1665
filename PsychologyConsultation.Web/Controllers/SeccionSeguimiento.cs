using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PsychologyConsultation.Domain.Entities;
using PsychologyConsultation.Infrastructure.Data;


namespace PsychologyConsultation.Web.Controllers
{
    public class SeccionSeguimientoController : Controller
    {
        // Acción para listar todas las secciones de seguimiento
        public IActionResult Index()
        {
            // Aquí iría la lógica para obtener las secciones desde la base de datos
            var secciones = new List<SeccionSeguimiento>
            {
                new SeccionSeguimiento { Id = 1, Fecha = DateTime.Now, Observaciones = "Primera sesión", Completada = false },
                new SeccionSeguimiento { Id = 2, Fecha = DateTime.Now.AddDays(1), Observaciones = "Segunda sesión", Completada = true }
            };

            return View(secciones);
        }

        // Acción para mostrar el formulario de creación
        public IActionResult Create()
        {
            return View();
        }

        // Acción para procesar el formulario de creación
        [HttpPost]
        public IActionResult Create(SeccionSeguimiento seccion)
        {
            if (ModelState.IsValid)
            {
                // Aquí iría la lógica para guardar en la base de datos
                return RedirectToAction("Index");
            }

            return View(seccion);
        }

        // Acción para mostrar el formulario de edición
        public IActionResult Edit(int id)
        {
            // Aquí iría la lógica para obtener la sección desde la base de datos
            var seccion = new SeccionSeguimiento
            {
                Id = id,
                Fecha = DateTime.Now,
                Observaciones = "Ejemplo de edición",
                Completada = false
            };

            return View(seccion);
        }

        // Acción para procesar el formulario de edición
        [HttpPost]
        public IActionResult Edit(SeccionSeguimiento seccion)
        {
            if (ModelState.IsValid)
            {
                // Aquí iría la lógica para actualizar en la base de datos
                return RedirectToAction("Index");
            }

            return View(seccion);
        }

        // Acción para mostrar la confirmación de eliminación
        public IActionResult Delete(int id)
        {
            // Aquí iría la lógica para obtener la sección desde la base de datos
            var seccion = new SeccionSeguimiento
            {
                Id = id,
                Fecha = DateTime.Now,
                Observaciones = "Ejemplo de eliminación",
                Completada = false
            };

            return View(seccion);
        }

        // Acción para procesar la eliminación
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            // Aquí iría la lógica para eliminar de la base de datos
            return RedirectToAction("Index");
        }
    }
}
