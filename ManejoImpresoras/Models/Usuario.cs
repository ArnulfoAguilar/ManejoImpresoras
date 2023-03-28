namespace ManejoImpresoras.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroRegistro { get; set; }
        public string Email  { get; set; }
        public string PasswordHash { get; set; }
        public int IdInstitucion { get; set; }

    }
}
