using ApiForo.Data;
using ApiForo.ForosMapper;
using ApiForo.Repository;
using ApiForo.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//configuracion sql server
builder.Services.AddDbContext<AplicationDbContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});

//agregamos los repositorios
builder.Services.AddScoped<IComentarioRepositorio,ComentarioRepositorio>();

//agregar el auto mapper
builder.Services.AddAutoMapper(typeof(ForosMapper));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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