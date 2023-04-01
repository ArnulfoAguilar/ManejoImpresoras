using System.ComponentModel.DataAnnotations;

namespace ManejoImpresoras.Entidades
{
    public class EstadoImpresora
    {
        public int IdEstado { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50)]
        public string Nombre { get; set;}

        [StringLength(100)]
        public String Descripcion { get;set;}
    }
}
