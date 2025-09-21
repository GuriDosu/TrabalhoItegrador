using Microsoft.EntityFrameworkCore; 
using TrabalhoItegrador.Data;
using TrabalhoItegrador.Models;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o contexto do banco de dados PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adiciona suporte a controllers e views (MVC)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura o pipeline de requisições
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Define a rota padrão do projeto
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
