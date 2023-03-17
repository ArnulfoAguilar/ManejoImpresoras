using Dapper;
using ManejoImpresoras.Models;
using System.Data.SqlClient;

namespace ManejoImpresoras.Servicios
{
    public interface IRepositorioInstituciones
    {
        void Crear(Institucion institucion);
    }

    public class RepositorioInstituciones : IRepositorioInstituciones
    {
        private readonly string connectionString;
        public RepositorioInstituciones(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Crear(Institucion institucion) 
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"insert into Institucion ( Nombre, Descripcion) values (@Nombre, @Descripcion); ";
            var idInstitucion =  connection.QuerySingle(query, institucion);

            // Select SCOPE_IDENTITY();
            //institucion.IdInstitucion = idInstitucion;
        }
    }
}
