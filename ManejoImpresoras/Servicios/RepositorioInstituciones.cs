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

        public RepositorioInstituciones(IConfiguration  configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Crear(Institucion institucion) 
        {
            using var connection = new SqlConnection(connectionString);
            // connection.Open();  
            var query = @"insert into Institucion (Nombre, Descripcion) values (@Nombre, @Descripcion); 
                            Select SCOPE_IDENTITY();";
                            
            var id = connection.QuerySingle<int>(query, institucion);   //Execute

            institucion.IdInstitucion = id;

        }
    }
    
}
