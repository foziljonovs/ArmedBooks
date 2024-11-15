using ArmedBooks.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services
    .AddContext(builder.Configuration)
    .AddServices();

var app = builder.Build();

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
