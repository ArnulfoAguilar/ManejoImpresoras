using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ManejoImpresoras.Models
{
    public class Usuario   : IdentityUser 
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(9)]
        [Display(Name="Número de Registro")]
        public string NumeroRegistro { get; set; }
        [Display(Name = "Institución")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdInstitucion { get; set; }
    }
}
