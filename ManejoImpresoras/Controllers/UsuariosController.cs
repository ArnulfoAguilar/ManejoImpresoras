using AutoMapper;
using ManejoImpresoras.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManejoImpresoras.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<Usuario> userManager;
        private readonly IMapper mapper;

        public UsuariosController(UserManager<Usuario> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }   
        public IActionResult Registro()
        {
            return View();
        }
   

    [HttpPost]
    public async Task<IActionResult> Registro(RegistroViewModel modelo) 
    {
        if (!ModelState.IsValid) 
        {
            return View(modelo);
        }

        var modelol = new { modelo };
        //var usuariol = mapper.Map<RegistroViewModel>(modelol);
        var usuario = new Usuario() {   Email = modelo.Email,
                                        Nombres = modelo.Nombres,   
                                        Apellidos = modelo.Apellidos,
                                        NumeroRegistro = modelo.NumeroRegistro, 
                                        PasswordHash = modelo.Password,
                                        IdInstitucion = modelo.IdInstitucion
        };

        var resultado =  await userManager.CreateAsync(usuario, password : modelo.Password);

            if (resultado.Succeeded)
            {
                return RedirectToAction("Index", "Transacciones");
            }
            else 
            {
                foreach (var error in resultado.Errors) 
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                }

                return View(modelo);
            }       
    }

    }
}
