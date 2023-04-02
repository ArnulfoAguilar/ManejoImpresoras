using AutoMapper;
using ManejoImpresoras.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ManejoImpresoras.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IMapper mapper;

        public UsuariosController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        public IActionResult Registro()
        {
            return View();
        }
   

    [HttpPost]
    [AllowAnonymous]
        public async Task<IActionResult> Registro(RegistroViewModel modelo) 
    {
        if (!ModelState.IsValid) 
        {
            return View(modelo);
        }

        //var usuariol = mapper.Map<RegistroViewModel>(modelol);
        var usuariovy = new Usuario() {   Email = modelo.Email,
                                        Nombres = modelo.Nombres,   
                                        Apellidos = modelo.Apellidos,
                                        NumeroRegistro = modelo.NumeroRegistro, 
                                        PasswordHash = modelo.Password,
                                        IdInstitucion = modelo.IdInstitucion
        };

            var usuario = new IdentityUser()
            {
                Email = modelo.Email,
                UserName = modelo.Nombres
            };
                var resultado =  await userManager.CreateAsync(usuario, password : modelo.Password);

            if (resultado.Succeeded)
            {
                await signInManager.SignInAsync(usuario, isPersistent: true);
                return RedirectToAction("Index", "Instituciones"); // Home (Instituciones)
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
