using WebAPICVA.Data;
using Microsoft.EntityFrameworkCore;
using WebAPICVA.Repositories;
using WebAPICVA.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPICVA.Extensiones;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TokenBlacklistService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

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

/*
Codigo de Pruebas
 */


// Agregar middleware de autenticación JWT al pipeline
app.UseMiddleware<JwtMiddleware>();

// Usar middleware de autenticación
app.UseAuthentication();

// Usar middleware de autorización
app.UseAuthorization();

// Mapear los controladores
app.MapControllers();

// Configurar la base de datos y migraciones al inicio
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate();
}

// Ejecutar la aplicación
app.Run();






/*app.UseAuthorization();
app.MapControllers();
app.Run();*/
