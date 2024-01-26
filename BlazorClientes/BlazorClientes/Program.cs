using BlazorClientes.Components;
using BlazorClientes.Context;
using BlazorClientes.Repositories;
using BlazorClientes.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();
var connectionString = builder.Configuration
                              .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ClienteContext>(opt =>
                                               opt.UseSqlServer(connectionString));
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

                                            
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorClientes.Client._Imports).Assembly);

app.Run();
