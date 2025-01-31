using Microsoft.EntityFrameworkCore;
using WebAPICVA.Models;

namespace WebAPICVA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<SocioNegocio> SocioNegocio { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<BancoDetalle> BancoDetalle { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<IngresosDetalle> IngresosDetalle { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<FacturaCompra> FacturaCompra { get; set; }
        public DbSet<FacturaVenta> FacturaVenta { get; set; }
        public DbSet<FacturaCompraDetalle> FacturaCompraDetalle { get; set; }
        public DbSet<FacturaVentaDetalle> FacturaVentaDetalle { get; set; }
    }
}