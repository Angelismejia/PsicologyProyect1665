using Microsoft.EntityFrameworkCore;
using PsychologyConsultation.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de la conexi�n a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Agregar controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuraci�n del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
