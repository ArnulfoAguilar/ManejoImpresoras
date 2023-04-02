using System.ComponentModel.DataAnnotations;

namespace ManejoImpresoras.Entidades
{
    public class Impresora
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(20)]
        public string CodigoActivoFijo { get; set;}
        [StringLength(50)]
        public string Marca { get; set; }
        [StringLength(50)]  
        public string Modelo { get; set; } 
        public int IdEstado { get; set; }  //Deberia ser IdEstadoImpresora 
        public EstadoImpresora EstadoImpresora { get; set; }
        public int EsdeColor { get; set;}
        [StringLength(15)]
        public int DireccionIP { get; set; }
        [StringLength(150)]
        public string Caracteristicas { get; set; }
    }
}
