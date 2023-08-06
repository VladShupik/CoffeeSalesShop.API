using CoffeeSalesShop.API.Data;
using CoffeeSalesShop.API.Interfaces;
using CoffeeSalesShop.API.Middlewares;
using CoffeeSalesShop.API.Services;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

//Setup supported cultures in app
var supportedCultures = new[]
    {
        new CultureInfo("en-US"),
        new CultureInfo("ru-RU"),
        new CultureInfo("uk-UA")
    };

//Setup localization
builder.Services.AddLocalization();

//Setup own services
builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddSingleton<CoffeeSalesShopContext>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Add own middlewares
app.UseMiddleware<ExceptionMiddleware>();
app.UseMiddleware<LanguageMiddleware>();

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("uk-UA"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

app.MapControllers();

app.Run();
