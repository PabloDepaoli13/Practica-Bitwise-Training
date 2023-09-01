using AppBibliotecaBitwise4.DAL.DataContext;
using AppBibliotecaBitwise4.DAL.Implementacion;
using AppBibliotecaBitwise4.DAL.Interface;
using AppBibliotecaBitwise4.Utilidades;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AplicationContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddTransient(typeof(IGenericInterface<>), typeof(GenericInterface<>));

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
