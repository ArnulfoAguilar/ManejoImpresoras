using ManejoImpresoras.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ManejoImpresoras
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Impresora>().Property(i => i.CodigoActivoFijo).HasMaxLength(20).IsRequired();
        }
        public DbSet<Impresora> Impresoras { get; set; }    
        public DbSet<EstadoImpresora> EstadosImpresoras { get; set; }
    }
}
