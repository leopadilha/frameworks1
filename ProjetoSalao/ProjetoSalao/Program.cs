using Microsoft.EntityFrameworkCore;
using ProjetoSalao.Data;
using ProjetoSalao.Repository.ClientRepository;
using ProjetoSalao.Repository.ProductRepository;
using ProjetoSalao.Repository.ProviderRepository;
using ProjetoSalao.Repository.SchedulingRepository;
using ProjetoSalao.Repository.ServiceRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BancoContext>(
o => o.UseNpgsql(builder.Configuration.GetConnectionString("Agendamento")));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<ISchedulingRepository, SchedulingRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

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
