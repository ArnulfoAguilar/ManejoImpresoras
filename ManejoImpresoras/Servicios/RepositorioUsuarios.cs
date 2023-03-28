using Dapper;
using ManejoImpresoras.Models;
using System.Data.SqlClient;

namespace ManejoImpresoras.Servicios
{
    public interface IRepositorioUsuarios
    {
        Task<Usuario> BuscaUsuarioPorEmail(string email);
        Task<Usuario> BuscaUsuarioPorNombre(string nombre);
        Task<int> CrearUsuario(Usuario usuario);
    }
    public class RepositorioUsuarios : IRepositorioUsuarios
    {
        private readonly string connectionString;
        
        public RepositorioUsuarios(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<int> CrearUsuario(Usuario usuario) 
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"insert into usuario (Id, Nombres, Apellidos, NumeroRegistro, Email, PasswordHash, IDInstitucion)
                        values (@Id, @Nombres, @Apellidos, @NumeroRegistro, @Email, @PasswordHash, @IDInstitucion); 
                        Select SCOPE_IDENTITY();";
            var id = await connection.QuerySingleAsync<int>(query, usuario);

            return id;
        }

        public async Task<Usuario> BuscaUsuarioPorEmail(String email)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"Select * from usuario where Email = @Email;";
            return await connection.QuerySingleOrDefaultAsync<Usuario>(query, new { email });
        }

        public async Task<Usuario> BuscaUsuarioPorNombre(String nombres)
        {
            using var connection = new SqlConnection(connectionString);
            var query = @"Select * from usuario where upper(Nombres) = @Nombres;";
            return await connection.QuerySingleOrDefaultAsync<Usuario>(query, new { nombres });
        }
    }
}
