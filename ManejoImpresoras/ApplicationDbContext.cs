using ManejoImpresoras.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ManejoImpresoras
{
    public class ApplicationDbContext : IdentityDbContext   

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
