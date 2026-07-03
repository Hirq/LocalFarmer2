global using AutoMapper;
global using LocalFarmer2.Shared.DTOs;
global using LocalFarmer2.Shared.ENUMs;
global using LocalFarmer2.Shared.Models;
global using LocalFarmer2.Shared.Resources;
global using Microsoft.Extensions.Localization;
global using System.Net.Http.Json;
using Blazored.LocalStorage;
using LocalFarmer2.Client;
using LocalFarmer2.Client.Services;
using LocalFarmer2.Client.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using MudBlazor.Services;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<JwtAuthorizationMessageHandler>();
builder.Services.AddHttpClient("AuthorizedClient", client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
})
.AddHttpMessageHandler<JwtAuthorizationMessageHandler>();

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>()
      .CreateClient("AuthorizedClient"));
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFarmhouseService, FarmhouseService>();
builder.Services.AddScoped<IFavoriteFarmhouseService, FavoriteFarmhouseService>();
builder.Services.AddScoped<IOpinionService, OpinionService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IChatMessageService, ChatMessageService>();
builder.Services.AddScoped<IAlertPremiumService, AlertPremiumService>();
builder.Services.AddScoped<UserStateService>();
builder.Services.AddScoped<UtilsService>();
builder.Services.AddScoped<SearchService>();
builder.Services.AddSingleton<ValidateService>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddSingleton(sp => builder.Configuration.GetSection("AppSettings").Get<AppSettings>());

builder.Services.AddLocalization();

var host = builder.Build();

//Set culture from localStorage
var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
var cultureName = result ?? "en-US";

var culture = new CultureInfo(cultureName);

culture.DateTimeFormat.ShortDatePattern = cultureName == "pl-PL"
    ? "dd.MM.yyyy"
    : "MM/dd/yyyy";

CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

await host.RunAsync();
