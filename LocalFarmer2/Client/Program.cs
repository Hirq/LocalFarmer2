global using AutoMapper;
global using System.Net.Http.Json;
global using LocalFarmer2.Shared.Models;
using Blazored.LocalStorage;
using LocalFarmer2.Client;
using LocalFarmer2.Client.Services;
using LocalFarmer2.Client.Utilities;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFarmhouseService, FarmhouseService>();
builder.Services.AddScoped<IFavoriteFarmhouseService, FavoriteFarmhouseService>();
builder.Services.AddScoped<UserStateService>();
builder.Services.AddSingleton<AlertService>();
builder.Services.AddSingleton<UtilsService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


await builder.Build().RunAsync();
