using Microsoft.EntityFrameworkCore;
using WebAPICVA.DTOs;
using WebAPICVA.Models;

namespace WebAPICVA.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Productos> Productos { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<SocioNegocio> SocioNegocio { get; set; }
        public DbSet<Banco> Banco { get; set; }
        public DbSet<BancoDetalle> BancoDetalle { get; set; }
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Ingresos> Ingresos { get; set; }
        public DbSet<Egresos> Egresos { get; set; }
        public DbSet<Transacciones> Transacciones { get; set; }
        public DbSet<IngresosDetalle> IngresosDetalle { get; set; }
        public DbSet<TransaccionDetalle> TransaccionDetalle { get; set; }
        public DbSet<Tipo> Tipo { get; set; }
        public DbSet<FacturaCompra> FacturaCompra { get; set; }
        public DbSet<FacturaVenta> FacturaVenta { get; set; }
        public DbSet<FacturaCompraDetalle> FacturaCompraDetalle { get; set; }
        public DbSet<FacturaVentaDetalle> FacturaVentaDetalle { get; set; }
        public DbSet<TokenBlacklist> TokenBlacklist { get; set; }
        public DbSet<MetodoPago> MetodoPago { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<Subtipos> Subtipos { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngresosDetalle>()
            .HasOne(d => d.Ingreso) // Un detalle pertenece a un ingreso
            .WithMany(i => i.IngresosDetalles) // Un ingreso puede tener muchos detalles
            .HasForeignKey(d => d.Id_Ingreso) // La clave foránea es Id_Ingreso
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina un ingreso, se eliminan los detalles


            modelBuilder.Entity<TransaccionDetalle>()
            .HasOne(d => d.Transaccion) // Un detalle pertenece a una Transaccion
            .WithMany(i => i.TransaccionesDetalles) // Un ingreso puede tener muchos detalles
            .HasForeignKey(d => d.Id_Transaccion) // La clave foránea es Id_Transaccion
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina un ingreso, se eliminan los detalles

            modelBuilder.Entity<FacturaVentaDetalle>()
            .HasOne(d => d.FacturaVentas) // Un detalle pertenece a una Factura Venta
            .WithMany(i => i.FacturaVentasDetalles) // Un ingreso puede tener muchos detalles
            .HasForeignKey(d => d.Id_Factura_Venta) // La clave foránea es Id_Factura_Venta
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina un ingreso, se eliminan los detalles

            modelBuilder.Entity<FacturaCompraDetalle>()
            .HasOne(d => d.FacturaCompras) // Un detalle pertenece a una Factura Venta
            .WithMany(i => i.FacturaComprasDetalles) // Un ingreso puede tener muchos detalles
            .HasForeignKey(d => d.Id_Factura_Compra) // La clave foránea es Id_Factura_Venta
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina un ingreso, se eliminan los detalles

            modelBuilder.Entity<BancoDetalle>()
            .HasOne(d => d.Bancos) // Un detalle pertenece a una Factura Venta
            .WithMany(i => i.BancoDetalles) // Un ingreso puede tener muchos detalles
            .HasForeignKey(d => d.Id_Banco) // La clave foránea es Id_Factura_Venta
            .OnDelete(DeleteBehavior.Cascade); // Si se elimina un ingreso, se eliminan los detalles
        }
    }
}