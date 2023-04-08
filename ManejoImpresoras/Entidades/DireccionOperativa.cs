using System.ComponentModel.DataAnnotations;

namespace ManejoImpresoras.Entidades
{
    public class DireccionOperativa
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(125)]
        public String Enlace { get; set; }
     }
}
