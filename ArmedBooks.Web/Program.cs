using ArmedBooks.Web.Configurations;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddViewLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportCulture = new[] { "en", "uz", "ru", "tr" };
    options.SetDefaultCulture("uz")
        .AddSupportedCultures(supportCulture)
        .AddSupportedUICultures(supportCulture);
});

builder.Services
    .AddContext(builder.Configuration)
    .AddServices();

var app = builder.Build();

var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);

if (!app.Environment.IsDevelopment() && !app.Environment.IsProduction())
{
    app.UseExceptionHandler("/Home/Error");
}

if(app.Configuration.GetValue<bool>("UseHttps"))
{
    app.UseHttpsRedirection();
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
