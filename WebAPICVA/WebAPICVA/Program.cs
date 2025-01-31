using WebAPICVA.Data;
using Microsoft.EntityFrameworkCore;
using WebAPICVA.Repositories;
using WebAPICVA.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar el repositorio y el servicio en la inyección de dependencias
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ISocioNegocioRepository, SocioNegocioRepository>();
builder.Services.AddScoped<ISocioNegocioService, SocioNegocioService>();
builder.Services.AddScoped<IBancoRepository, BancoRepository>();
builder.Services.AddScoped<IBancoService, BancoService>();
builder.Services.AddScoped<ICuentasRepository, CuentasRepository>();
builder.Services.AddScoped<ICuentasService, CuentasService>();
builder.Services.AddScoped<IIngresosRepository, IngresosRepository>();
builder.Services.AddScoped<IIngresosService, IngresosService>();
builder.Services.AddScoped<ITipoRepository, TipoRepository>();
builder.Services.AddScoped<ITipoService, TipoService>();
builder.Services.AddScoped<IFacturaCompraRepository, FacturaCompraRepository>();
builder.Services.AddScoped<IFacturaCompraService, FacturaCompraService>();
builder.Services.AddScoped<IFacturaVentaRepository, FacturaVentaRepository>();
builder.Services.AddScoped<IFacturaVentaService, FacturaVentaService>();
builder.Services.AddScoped<IFacturaCompraDetalleRepository, FacturaCompraDetalleRepository>();
builder.Services.AddScoped<IFacturaCompraDetalleService, FacturaCompraDetalleService>();
builder.Services.AddScoped<IFacturaVentaDetalleRepository, FacturaVentaDetalleRepository>();
builder.Services.AddScoped<IFacturaVentaDetalleService, FacturaVentaDetalleService>();
builder.Services.AddScoped<IBancoDetalleRepository, BancoDetalleRepository>();
builder.Services.AddScoped<IBancoDetalleService, BancoDetalleService>();
builder.Services.AddScoped<IIngresosDetalleRepository, IngresosDetalleRepository>();
builder.Services.AddScoped<IIngresosDetalleService, IngresosDetalleService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
