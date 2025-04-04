using WebAPICVA.Data;
using Microsoft.EntityFrameworkCore;
using WebAPICVA.Repositories;
using WebAPICVA.Services;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebAPICVA.Extensiones;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<TokenBlacklistService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

//var secretKey = "v@8vG3#xU!9zP$YkW6rE^tM2L&dC7qN%"; // Debe coincidir con AuthService
var secretKey = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]);

/* -----------------------------------------------------------------------------------------*/
/* Codigo de Obsoleto 
var key = Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:SecretKey"]);
var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);
var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Secret"]);*/
/* -----------------------------------------------------------------------------------------*/

//var key = Encoding.UTF8.GetBytes(secretKey);
//var jwtSettings = builder.Configuration.GetSection("JwtSettings");

Console.WriteLine($"🔍 Clave secreta usada: {secretKey}");


/* ----------------------------------------------------- */
/* Codigo de Obsoleto 
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key), // Asegúrate de que sea la misma clave usada para generar los tokens
        ValidateIssuer = false,  // Desactiva validación de Issuer si no lo usas
        ValidateAudience = false, // Desactiva validación de Audience si no lo usas
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero  // Evita tolerancia de tiempo en la expiración del token
    };
});*/
/* ----------------------------------------------------- */


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)), // ⚠️ Debe ser la misma clave usada en el token
            IssuerSigningKey = new SymmetricSecurityKey(secretKey), // ⚠️ Debe ser la misma clave usada en el token

            ValidateIssuer = true,
            ValidIssuer = "WebAPICVA",

            ValidateAudience = true,
            ValidAudience = "DesktopAplicationCV",

            ValidateLifetime = true, // Expiración del token

            ClockSkew = TimeSpan.Zero // Asegurar que no haya tiempo extra en la validación

            /* Codigo Obsoleto 
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
            */
        };

        /* Codigo de Obsoleto
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Valida la clave del emisor
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),

            // Si necesitas validar el emisor (issuer), agrega esta validación:
            ValidateIssuer = true,
            ValidIssuer = "WebAPICVA", // Asegúrate de que este sea el emisor correcto

            // Valida la audiencia (audience)
            ValidateAudience = true,
            ValidAudience = "DesktopAplicationCV", // Asegúrate de que esta sea la audiencia correcta

            // Validación de la expiración del token
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Esto ayuda si el tiempo de vida tiene un pequeño desfase
        };*/

        // Event handlers
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                Console.WriteLine("🔍 Headers recibidos:");
                foreach (var header in context.Request.Headers)
                {
                    Console.WriteLine($"{header.Key}: {header.Value}");
                }

                Console.WriteLine("🔴 StatusCode: " + context.Response.StatusCode);

                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    var rawToken = context.Request.Headers["Authorization"].ToString();
                    Console.WriteLine($"🔍 Header Authorization recibido: {rawToken}");

                    // Separa "Bearer " y muestra el token solo
                    if (rawToken.StartsWith("Bearer "))
                    {
                        var tokenOnly = rawToken.Substring(7);
                        Console.WriteLine($"🔍 Token limpio: {tokenOnly}");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ No se encontró el encabezado Authorization.");
                }

                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("🟢 Token validado correctamente en el middleware.");
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                /*Console.WriteLine($"🔴 Error de autenticación: {context.Exception.Message}");
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("Token-Expired", "true");
                }
                return Task.CompletedTask;*/

                Console.WriteLine($"🔴 Error de autenticación: {context.Exception.Message}");

                // Captura y muestra el token recibido
                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    var rawToken = context.Request.Headers["Authorization"].ToString();
                    Console.WriteLine($"📢 Token recibido: {rawToken}");
                }
                else
                {
                    Console.WriteLine("❌ No se recibió un token en la cabecera Authorization.");
                }

                return Task.CompletedTask;
            }
        };

        /* Codigo de respaldo*/
        /*options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                Console.WriteLine("🔍 Headers recibidos:");
                foreach (var header in context.Request.Headers)
                {
                    Console.WriteLine($"{header.Key}: {header.Value}");
                }

                if (context.Request.Headers.ContainsKey("Authorization"))
                {
                    var rawToken = context.Request.Headers["Authorization"].ToString();
                    Console.WriteLine($"🔍 Header Authorization recibido: {rawToken}");

                    // Separa "Bearer " y muestra el token solo
                    if (rawToken.StartsWith("Bearer "))
                    {
                        var tokenOnly = rawToken.Substring(7);
                        Console.WriteLine($"🔍 Token limpio: {tokenOnly}");
                    }
                }
                else
                {
                    Console.WriteLine("⚠️ No se encontró el encabezado Authorization.");
                }

                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"🔴 Error de autenticación: {context.Exception.Message}");
                return Task.CompletedTask;
            }
        };*/
    });




builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 204857600; // 100MB
});

builder.Services.AddAuthorization();

/* ---------------------------------- */
/* Codigo Obsoleto
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EstaEsUnaClaveMuySeguraDe32Caracteres!")),
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero // Importante: evitar tolerancia de tiempo
    };
});

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],
            ClockSkew = TimeSpan.Zero
        };
    });

 var key = Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]);

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
    });*/
/* ---------------------------------- */

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
builder.Services.AddScoped<IEgresosRepository, EgresosRepository>();
builder.Services.AddScoped<IEgresosService, EgresosService>();
builder.Services.AddScoped<ITransaccionesRepository, TransaccionesRepository>();
builder.Services.AddScoped<ITransaccionesService, TransaccionesService>();
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
builder.Services.AddScoped<IMetodoPagoRepository, MetodoPagoRepository>();
builder.Services.AddScoped<IMetodoPagoService, MetodoPagoService>();
builder.Services.AddScoped<ISubTiposRepository, SubTiposRepository>();
builder.Services.AddScoped<ISubTiposService, SubTiposService>();
builder.Services.AddScoped<IMonedasRepository, MonedasRepository>();
builder.Services.AddScoped<IMonedasService, MonedasService>();
builder.Services.AddScoped<ITransaccionDetalleRepository, TransaccionDetalleRepository>();
builder.Services.AddScoped<ITransaccionDetalleService, TransaccionDetalleService>();

//builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // Evita problemas con camelCase
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

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

/* ------------------------ */
/* Codigo Obsoleto
app.UseAuthorization();
app.MapControllers();
app.Run();*/
/* ------------------------ */
