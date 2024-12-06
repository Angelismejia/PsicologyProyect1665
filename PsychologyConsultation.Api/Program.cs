using PsychologyConsultation.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();

// Registra tus servicios de aplicación.
builder.Services.AddScoped<IConsultaService, IConsultaService>(); 
// Aquí registras tu interfaz y su implementación

// Agrega soporte para Swagger si es necesario.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura el pipeline de la aplicación.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
