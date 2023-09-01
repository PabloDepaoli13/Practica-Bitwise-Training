using AppBibliotecaBitwise5.DAL.DataContext;
using AppBibliotecaBitwise5.DAL.Implementacion;
using AppBibliotecaBitwise5.DAL.Interface;
using AppBibliotecaBitwise5.Utilidades;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicationContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
builder.Services.AddTransient(typeof(IGenericContract<>), typeof(GenericImplementation<>));
builder.Services.AddAutoMapper(typeof(MapperPerfile));
builder.Services.AddScoped<ILibroRepository, GenericLibro>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
