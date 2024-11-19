global using AutoMapper;
global using LocalFarmer2.Shared.DTOs;
global using LocalFarmer2.Shared.ENUMs;
global using LocalFarmer2.Shared.Models;
global using LocalFarmer2.Shared.Resources;
global using Microsoft.Extensions.Localization;
global using System.Net.Http.Json;
global using System.Net.Mail;
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
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IFarmhouseService, FarmhouseService>();
builder.Services.AddScoped<IFavoriteFarmhouseService, FavoriteFarmhouseService>();
builder.Services.AddScoped<IOpinionService, OpinionService>();
builder.Services.AddScoped<IAlertService, AlertService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<UserStateService>();
builder.Services.AddScoped<UtilsService>();
builder.Services.AddScoped<SearchService>();
builder.Services.AddSingleton<ValidateService>();
builder.Services.AddSingleton<FileService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddLocalization();

var host = builder.Build();

//Ustawienie kultury z localStorage
var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
var culture = result ?? "en-US";
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(culture);
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo(culture);

await host.RunAsync();
