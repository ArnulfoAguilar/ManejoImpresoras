using Microsoft.AspNetCore.Mvc;

namespace ManejoImpresoras.Controllers
{
    public class DireccionesOperativasController : Controller
    {
        public DireccionesOperativasController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
