// Program.cs
using PsychologyConsultation.Application.Contract;
using PsychologyConsultation.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor
builder.Services.AddScoped<IConsultaService, ConsultaService>();  // Registrar el servicio de consultas
builder.Services.AddScoped<IPacienteService, PacienteService>();  // Registrar el servicio de pacientes
builder.Services.AddScoped<ITratamientoService, TratamientoService>();  // Registrar el servicio de tratamientos
builder.Services.AddScoped<ISeccionSeguimientoService, SeccionSeguimientoService>(); // Registrar el servicio de sesión de seguimiento

// Agregar controladores y otros servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
