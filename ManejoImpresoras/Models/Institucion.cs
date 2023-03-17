using System.ComponentModel.DataAnnotations;

namespace ManejoImpresoras.Models
{
    public class Institucion
    {
        public int IdInstitucion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Nombre { get; set; }

        public String Descripcion { get; set; }
    }
}
