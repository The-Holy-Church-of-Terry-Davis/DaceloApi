using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Tester;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/*
string? origins = "origins";

builder.Services.AddCors(options =>
{
     options.AddPolicy(origins,
                           policy =>
                           {
                                policy.WithOrigins("http://localhost:9999")
                                                   .AllowAnyHeader()
                                                   .AllowAnyMethod();
                           });
});

app.UseCors(origins);*/

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
