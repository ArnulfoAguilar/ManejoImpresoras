using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ManejoImpresoras.Models
{
    public class Institucion
    {
        public int IdInstitucion { get; set; }


        [Remote(action: "VerificarExisteInstitucion", controller: "Instituciones", ErrorMessage = "Validacion Remota funionando")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name ="Nombre")]
        public String Nombre { get; set; }

        public String Descripcion { get; set; }
    }
}
