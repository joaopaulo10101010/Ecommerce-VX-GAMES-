using System.Globalization;
using LojaGames.Controllers;
using LojaGames.Models;
using LojaGames.Repositorios;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews();

/* ADICIONANDO OS REPOSITORIOS COMO SERVI�O */
builder.Services.AddScoped<UsuarioRepositorio>();
builder.Services.AddScoped<ProdutoRepositorio>();

builder.Services.AddDistributedMemoryCache(); /* Necess�rio para armazenar dados na mem�ria*/
builder.Services.AddSession(); /* Habilita a funcionalidade de sess�o */
builder.Services.AddHttpContextAccessor(); /* Permite injetar HttpContext nas views  */



var app = builder.Build();


app.UseSession(); // adicionando as variaveis de sessao no projeto


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
