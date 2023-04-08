using ManejoImpresoras.Entidades;
using ManejoImpresoras.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ManejoImpresoras.Controllers
{
    public class ImpresorasController : Controller
    {
        private readonly ApplicationDbContext _contexto;

        public ImpresorasController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var temp = await _contexto.Impresoras.ToListAsync();    
            return View(temp);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Impresora impresora)
        {
            if (ModelState.IsValid)
            {
                _contexto.Impresoras.Add(impresora); 
                await _contexto.SaveChangesAsync(); 
                return RedirectToAction("Index");   
            }
        
            return View();
        }

        public IActionResult NoEncontrado()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
