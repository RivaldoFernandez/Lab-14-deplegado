
using Lab_11_Fernandez.Application.Configuration;
using Lab_11_Fernandez.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Inyectar capas Application e Infrastructure
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("DefaultConnection"));

// 📄 Swagger y controladores
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🐞 Middleware para Swagger (solo en desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lab-11-Fernandez API v1");
        c.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}


// 🌐 Middlewares básicos
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 🧭 Ruta por defecto
app.MapGet("/", context =>
{
    context.Response.Redirect("/index.html");
    return Task.CompletedTask;
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
