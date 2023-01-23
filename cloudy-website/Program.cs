using Cloudy.CMS.Routing;
using cloudy_website.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCloudy(cloudy => cloudy
.AddAdmin(admin => admin.Unprotect())   // NOTE: Admin UI will be publicly available!
  .AddContext<SiteContext>()                // Adds EF Core context with your content types
);

builder.Services.AddDbContext<SiteContext>(options => options
  .UseCosmos(
    builder.Configuration.GetConnectionString("CosmosConnectionString") ?? throw new Exception("CosmosConnectionString needed"),
    builder.Configuration["CosmosDatabase"] ?? throw new Exception("CosmosDatabase needed"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(new StaticFileOptions().MustValidate()); // This removes the need for manually clearing browser cache when updating frontend assets
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

    endpoints.MapControllerRoute(
        name: "Product",
        pattern: "{controller=Product}/{action=Pricing}");

    endpoints.MapControllerRoute(
        name: "Resources",
        pattern: "{controller=Resources}/{action=business}");

    endpoints.MapControllerRoute(
        name: "About",
        pattern: "{controller=About}/{action=About}");

    endpoints.MapGet("/pages/{route:contentroute}", async c =>
        await c.Response.WriteAsync($"Hello {c.GetContentFromContentRoute<Page>().Name}")
    );

    endpoints.MapControllerRoute(null, "/controllertest/{route:contentroute}", new { controller = "Page", action = "Index" });
});

app.Run();

