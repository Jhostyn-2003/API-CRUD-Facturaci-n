using GavilanezJhostyn_ExamenU1_AS.Filters;
using GavilanezJhostyn_ExamenU1_AS.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//se agrega este para las excepciones globales
builder.Services.AddControllers(options =>
{
    // Registra el filtro de excepciones global
    options.Filters.Add(new GlobalExceptionFilter());
});

// Añadir el contexto de la bases de datos 
//builder.Services.AddDbContext<LibreriaContext>(); 
builder.Services.AddDbContext<GavilanezJFacturaExmContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibreriaConnection")));


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
