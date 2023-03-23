using ManejoImpresoras.Models;
using ManejoImpresoras.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace ManejoImpresoras.Controllers
{
    public class InstitucionesController : Controller
    {
        private readonly IRepositorioInstituciones repositorioInstituciones;

        public InstitucionesController(IRepositorioInstituciones repositorioInstituciones)
        {
            this.repositorioInstituciones = repositorioInstituciones;
        }

        public async Task<IActionResult> Index() 
        {
            var instituciones = await repositorioInstituciones.Obtener();
            return View(instituciones);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Crear(Institucion institucion)
        {
            if (!ModelState.IsValid)
            {
                return View(institucion);
            }

            var yaExisteInstitucion = await repositorioInstituciones.Existe(institucion.Nombre);

            if (yaExisteInstitucion) 
            {
                ModelState.AddModelError(nameof(institucion.Nombre), $"El nombre {institucion.Nombre} ya existe.");

                return View(institucion);

            }  

            await repositorioInstituciones.Crear(institucion);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public async Task<IActionResult> Editar(int idInstitucion)
        {
            var tempo = idInstitucion;
            if (tempo == 0)
                idInstitucion = 1;  

            var institucion = await repositorioInstituciones.ObtenerPorId(idInstitucion);
            if (institucion == null)
            {
                return RedirectToAction("Noencontrado","Home");
            }

            return View(institucion);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Institucion institucion) //* ActionResult
        {

            var institucionExiste = await repositorioInstituciones.ObtenerPorId(institucion.IdInstitucion);
            
            if (institucionExiste is null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }

            await repositorioInstituciones.Actualizar(institucion);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int idInstitucion) //* ActionResult
        {
            var institucion = await repositorioInstituciones.ObtenerPorId(idInstitucion);

            if (institucion is null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }

            await repositorioInstituciones.Actualizar(institucion);

            return View(institucion);
        }

        [HttpPost]
        public async Task<IActionResult> BorrarInstitucion(int idInstitucion) 
        {
            var institucion = await repositorioInstituciones.ObtenerPorId(idInstitucion);

            if (institucion is null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }

            await repositorioInstituciones.Borrar(idInstitucion);

            return RedirectToAction("Index");

        }

        [HttpGet]

        public async Task<IActionResult> VerificarExisteInstitucion(string nombre)
        {
            var yaExisteInstitucion = await repositorioInstituciones.Existe(nombre);
            if (yaExisteInstitucion)
            {
                return Json($"El nombre {nombre} ya existe.");
            }
            else 
            {
                return Json(true);
            }
            
        }
  
    }
}
    
