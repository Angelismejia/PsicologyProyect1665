using PsychologyConsultation.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();

// Registra tus servicios de aplicaci�n.
builder.Services.AddScoped<IConsultaService, IConsultaService>(); 
// Aqu� registras tu interfaz y su implementaci�n

// Agrega soporte para Swagger si es necesario.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura el pipeline de la aplicaci�n.
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
