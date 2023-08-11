using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton(ISOLib.Countries.Collection);
builder.Services.AddSingleton(ISOLib.Currencies.Collection);
builder.Services.AddSingleton(ISOLib.Languages.Collection);

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();