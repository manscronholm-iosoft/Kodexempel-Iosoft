
using Kodexempel.Application;
using Kodexempel.Application.Interfaces;
using Kodexempel.Blazor.Components;
using Kodexempel.Infrastructure;
using Kodexempel.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ****
//  Här lägger vi till våra tjänster i DI-containern och mappar interfaces mot implementationen.
//  På så sätt kan vi använda interfacen i våra komponenter och låta DI-containern sköta instansieringen av implementationen.
// ****
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieRentingService, MovieRentingService>();

// Add DbContext
builder.Services.AddDbContext<KodexempelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();