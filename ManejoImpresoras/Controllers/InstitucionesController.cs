using ManejoImpresoras.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManejoImpresoras.Controllers
{
    public class InstitucionesController : Controller
    {
        /*

                private readonly string connectionString;

                public InstitucionesController(IConfiguration configuration)
                {
                    connectionString = configuration.GetConnectionString("DefaultConnection");
                }
        */

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Institucion institucion)
        {
            return View();
        }

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
    
