using AppBibliotecaBitwise8.DAL.DataContext;
using AppBibliotecaBitwise8.DAL.Implementatios;
using AppBibliotecaBitwise8.DAL.Interfaces;
using AppBibliotecaBitwise8.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using XAct;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
        
    opt => opt.CacheProfiles.Add("CacheComun", new CacheProfile()
    {
        Duration = 60
    })
        
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(opt => 
{

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Codigo de Login",
        Name = "Authentication",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
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


builder.Services.AddDbContext<AplicationDataContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddScoped<ILibraryRepository, LibraryRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var key = builder.Configuration.GetValue<string>("APIConfig:ClaveSecreta");

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(e =>
{
    e.RequireHttpsMetadata = false;
    e.SaveToken = true;
    e.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };

});

builder.Services.AddCors(e => e.AddPolicy("PolicyCors", build =>
    build.WithOrigins("*").AllowCredentials().AllowAnyMethod()
));

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

app.UseCors();

app.MapControllers();

app.Run();
