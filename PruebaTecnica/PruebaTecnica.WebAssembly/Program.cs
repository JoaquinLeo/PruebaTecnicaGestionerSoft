using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PruebaTecnica.WebAssembly;

using Blazored.LocalStorage;
using Blazored.Toast;

using PruebaTecnica.WebAssembly.Servicios.Contrato;
using PruebaTecnica.WebAssembly.Servicios.Implementacion;

using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5051/api/") });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<INacionalidadServicio,NacionalidadServicio>();
builder.Services.AddScoped<IDeporteServicio, DeporteServicio>();
builder.Services.AddScoped<IDeportistaServicio, DeportistaServicio>();

builder.Services.AddSweetAlert2();

await builder.Build().RunAsync();
