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
        /*
                 private readonly string connectionString;

                public InstitucionesController(IConfiguration configuration)
                {
                    connectionString = configuration.GetConnectionString("DefaultConnection");
                }
        */
        /*
                  public IActionResult Crear()
                  {
                      using (var connection = new SqlConnection(connectionString))

                      {

                          var query = connection.Query("SELECT 1").FirstOrDefault();

                      }
                      return View();

                  }

           */
    }
}
    
