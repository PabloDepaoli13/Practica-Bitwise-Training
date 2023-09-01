using AppBibliotecaBitwise6.DAL.DataContext;
using AppBibliotecaBitwise6.DAL.Interface;
using AppBibliotecaBitwise6.DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using AppBibliotecaBitwise6.Utilidades;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    {
        Description = "¡Bienvenido a la Biblioteca Bitwise! \r\n\r\n" +
        " Para registrarte ingresa la palabra 'Bearer' seguida del Token \r\n\r\n" +
        "Ejemplo: \"Bearer fubweuqbnjknfjsvyuixcovyasdfqfasdygicuzyx\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        { 
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference{
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
});


builder.Services.AddDbContext<AplicationDbContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<ILibreryRepository, LibreryRepository>();
builder.Services.AddScoped<IUsuariosRepository, UsuarioRepository>();

var key = builder.Configuration.GetValue<string>("APIRespuesta:ClaveSecreta");

builder.Services.AddAuthentication(x =>
{
    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata= false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
