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

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Crear(Institucion institucion)
        {
            if (!ModelState.IsValid)
            {
                return View(institucion);
            }

            repositorioInstituciones.Crear(institucion);

            return View();

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
    
