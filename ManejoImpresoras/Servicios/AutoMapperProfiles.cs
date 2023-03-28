using AutoMapper;
using ManejoImpresoras.Models;

namespace ManejoImpresoras.Servicios
{
    public class AutoMapperProfiles :Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Usuario, RegistroViewModel>();
        }
    }
}
