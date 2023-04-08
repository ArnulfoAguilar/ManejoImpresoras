using ManejoImpresoras;
using ManejoImpresoras.Models;
using ManejoImpresoras.Servicios;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Only user authentication 
var politicaUsuariosAutenticados = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser().Build(); 

// Add services to the container.
builder.Services.AddControllersWithViews(opciones =>
{
    opciones.Filters.Add(new AuthorizeFilter(politicaUsuariosAutenticados));
});

//  Add services my (VY) DbContext ***************************************  
builder.Services.AddDbContext<ApplicationDbContext>
    (opciones => opciones.UseSqlServer("name=DefaultConnection"));

 //(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("name=DefaultConnection")));

//Add services  Authenticatios (VY)
builder.Services.AddAuthentication();
//Aqui defino (VY )cual es la clase que se utilizara para authenticar "IdentityUser" es por Defecto
builder.Services.AddIdentity<IdentityUser, IdentityRole>(opciones => 
{opciones.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
//Para no utilizar las vistas utilizadas por defecto, Defino entos las URL  
builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme,
    opciones =>
    {
        opciones.LoginPath = "/usuarios/login";
        opciones.AccessDeniedPath = "/usuarios/login";
    });

builder.Services.AddTransient<IRepositorioInstituciones, RepositorioInstituciones>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IRepositorioUsuarios, RepositorioUsuarios>();

//  Deberia de Eliminarlos ya que corresponde a la Authentications anterior (Semi-Manual)
builder.Services.AddTransient<IUserStore<Usuario>, UsuarioStore>();
builder.Services.AddIdentityCore<Usuario>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//Middeleware 
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
