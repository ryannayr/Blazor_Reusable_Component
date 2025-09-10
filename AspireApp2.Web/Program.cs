using AspireApp2.Web;
using AspireApp2.Web.Components;
using AspireApp2.Web.Components.atomic.models;
using AspireApp2.Web.Components.atomic.pages.textinput;
using AspireApp2.Web.Components.atomic.validators;
using FluentValidation;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();
builder.Services.AddAntiforgery();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOutputCache();
builder.Services.AddRadzenComponents();

builder.Services.AddHttpClient<WeatherApiClient>(client =>
    {
        // This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
        // Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
        client.BaseAddress = new("https+http://apiservice");
    });

builder.Services.AddScoped<IValidator<TextValueModel>, TextValueModelValidator>();
builder.Services.AddScoped<IValidator<TextInputModel>, TextInputModelValidator>();
builder.Services.AddScoped<IValidator<DateValueModel>, DateValueModelValidator>();
builder.Services.AddScoped<IValidator<DateInputModel>, DateInputModelValidator>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.UseOutputCache();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
