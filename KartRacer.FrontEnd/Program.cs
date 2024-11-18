using KartRacer.FrontEnd;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using MudBlazor.Services;
using Blazored.LocalStorage;
using KartRacer.FrontEnd.Providers;
using KartRacer.FrontEnd.Services.Auth;
using KartRacer.FrontEnd.Services.Base;
using KartRacer.FrontEnd.Services.TokenProvider;
using KartRacer.FrontEnd.Services.User;
using KartRacer.FrontEnd.Services.Driver;
using KartRacer.FrontEnd.Services.Setup;
using KartRacer.FrontEnd.Services.KartShop;
using KartRacer.FrontEnd.Services.Event;
using KartRacer.FrontEnd.Services.Results;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Local", options.ProviderOptions);
});

builder.Services.AddHttpClient("KartRacerAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7224/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddScoped<ApiAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(p =>
                p.GetRequiredService<ApiAuthenticationStateProvider>());
builder.Services.AddAuthorizationCore();

builder.Services.AddHttpClient<IAuthService, AuthService>();


builder.Services.AddScoped<ITokenProvider, TokenProvider>();
builder.Services.AddScoped<IBaseService, BaseService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDriverService, DriverService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IKartShopService, KartShopService>();
builder.Services.AddScoped<IResultService, ResultService>();
builder.Services.AddScoped<ISetupService, SetupService>();



builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>()
    .CreateClient("KartRacerAPI"));



builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
