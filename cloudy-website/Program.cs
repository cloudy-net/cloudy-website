using cloudy_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration);
builder.Services.AddCloudy(cloudy => cloudy
    .AddAdmin()
    .AddContext<SiteContext>()
);

builder.Services.AddDbContext<SiteContext>(options => options
  .UseCosmos(
    builder.Configuration.GetConnectionString("CosmosConnectionString") ?? throw new Exception("CosmosConnectionString needed"),
    builder.Configuration["CosmosDatabase"] ?? throw new Exception("CosmosDatabase needed"))
);

builder.Services.Configure<AuthorizationOptions>(o => o.AddPolicy("adminarea", builder => builder.RequireAuthenticatedUser()));

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

app.MapRazorPages();
app.MapControllers();

app.MapControllerRoute(null, "/p/{route:contentroute}", new { controller = "Page", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "Product",
    pattern: "{controller=Product}/{action=Pricing}");

app.MapControllerRoute(
    name: "Resources",
    pattern: "{controller=Resources}/{action=business}");

app.MapControllerRoute(
    name: "About",
    pattern: "{controller=About}/{action=About}");

app.Run();
