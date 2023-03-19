using Dapper;
using ManejoImpresoras.Models;
using System.Data.SqlClient;

namespace ManejoImpresoras.Servicios
{
    public interface IRepositorioInstituciones
    {
        Task Actualizar(Institucion institucion);
        Task Crear(Institucion institucion);
        Task<bool> Existe(string nombre);
        Task<IEnumerable<Institucion>> Obtener();
        Task<Institucion> ObtenerPorId(int idIdInstitucion);
    }
    public class RepositorioInstituciones : IRepositorioInstituciones
    {
        private readonly string connectionString;

        public RepositorioInstituciones(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task Crear(Institucion institucion)
        {
            using var connection = new SqlConnection(connectionString);
            // connection.Open();  
            var query = @"insert into Institucion (Nombre, Descripcion) values (@Nombre, @Descripcion); 
                            Select SCOPE_IDENTITY();";

            var id = await connection.QuerySingleAsync<int>(query, institucion);   //Execute

            institucion.IdInstitucion = id;

        }

        public async Task<bool> Existe(string nombre)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"select 1 from Institucion where Nombre = @Nombre;";
            var existe = await connection.QueryFirstOrDefaultAsync<int>(query, new { nombre });

            return existe == 1;
        }

        public async Task<IEnumerable<Institucion>> Obtener()
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"select * from Institucion;";
            return await connection.QueryAsync<Institucion>(query);
        }

        public async Task Actualizar(Institucion institucion)
        {
            using var connection = new SqlConnection(connectionString);
            // connection.Open();  
            var query = @"Update Institucion 
                set Nombre = @Nombre, Descripcion = @Descripcion
                where IdInstitucion = @IdInstitucion;";

            await connection.ExecuteAsync(query, institucion);
        }

        public async Task<Institucion> ObtenerPorId(int idIdInstitucion)
        {
            using var connection = new SqlConnection(connectionString);
            // connection.Open();  
            var query = @"Select Nombre, Descripcion from Institucion
                                where IdInstitucion =  @IdInstitucion;";

           return await connection.QueryFirstOrDefaultAsync(query, new { idIdInstitucion });
        }
    }
}

