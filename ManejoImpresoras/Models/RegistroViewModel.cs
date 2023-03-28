using System.ComponentModel.DataAnnotations;

namespace ManejoImpresoras.Models
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Apellidos { get; set; }

        [Display(Name ="Numero de Registro")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String NumeroRegistro { get; set; }

        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage ="El campo {0} es requerido")]
        [EmailAddress(ErrorMessage = "El campo debe ser un correo electrónico válido")]
        public String Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int IdInstitucion { get; set; }
    }
}
