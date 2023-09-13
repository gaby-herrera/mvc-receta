using Microsoft.EntityFrameworkCore;
using Recetasweb.BL.Service;
using Recetasweb.DAL.DataContext;
using Recetasweb.DAL.Repositories;
using Recetasweb.EN;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RecetasDbContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

builder.Services.AddScoped<IGenericRepository<Recetas>, RecetasRepository>();
builder.Services.AddScoped<IRecetaService, RecetaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
