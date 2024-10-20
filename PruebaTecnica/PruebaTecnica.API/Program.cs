using PruebaTecnica.Repositorio.DBContext;
using Microsoft.EntityFrameworkCore;

using PruebaTecnica.Repositorio.Contrato;
using PruebaTecnica.Repositorio.Implementacion;

using PruebaTecnica.Utilidades;

using PruebaTecnica.Servicio.Contrato;
using PruebaTecnica.Servicio.Implementacion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PruebaTecnicaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQL"));
});

//AddTransient se utiliza porque no se sabe que modelo va a ser utilizado. En este sistema puede ser el de deporte, deportista, o nacionalidad
builder.Services.AddTransient(typeof(IGenericoRepositorio<>), typeof(GenericoRepositorio<>));

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddScoped<INacionalidadServicio,NacionalidadServicio>();
builder.Services.AddScoped<IDeporteServicio, DeporteServicio>();
builder.Services.AddScoped<IDeportistaServicio, DeportistaServicio>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("NuevaPolitica", app =>
    {
        app.AllowAnyOrigin().
        AllowAnyHeader().
        AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NuevaPolitica"); 

app.UseAuthorization();

app.MapControllers();

app.Run();
