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
        [ValidateAntiForgeryToken]  //Para validar ataques 
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

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null) 
            {
                return RedirectToAction("Noencontrado", "Home");
            }

            var contacto = _contexto.Impresoras.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);  

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Impresora impresora)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(impresora);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));  //  return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }

            var contacto = _contexto.Impresoras.Find(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);

        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]  //Para validar ataques 
        public async Task<IActionResult> BorrarImpresora(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Noencontrado", "Home");
            }

            var contacto = await _contexto.Impresoras.FindAsync(id);

            if (contacto == null)
            {
                return NotFound();
            }

            // Borrado de registro
            _contexto.Impresoras.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
