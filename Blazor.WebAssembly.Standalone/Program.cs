using Blazor.WebAssembly.Standalone;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var functionUrl = builder.HostEnvironment.IsDevelopment() ? builder.Configuration["AzureFunctionsEndpoint"] : builder.HostEnvironment.BaseAddress;

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(functionUrl) });

await builder.Build().RunAsync();
