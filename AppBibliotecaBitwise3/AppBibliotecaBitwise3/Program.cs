using AppBibliotecaBitwise3.DAL.DataContext;
using AppBibliotecaBitwise3.DAL.Interfaces;
using AppBibliotecaBitwise3.DAL.Implementaciones;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AppBibliotecaBitwise3.Utilidades;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbAplicationContext>(e => e.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL")));
builder.Services.AddTransient(typeof(IGenericInterface<>), typeof(GenericInterface<>));
builder.Services.AddAutoMapper(typeof(AutoMapperClass));

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
