using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using MyPortfolioProject.DAL.Context;
using MyPortfolioProject.DAL.Entities;
using MyPortfolioProject.DAL.Extensions;
using System.Diagnostics;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

// ---- Helper Methods ----
bool IsSqlServerAvailable(string connectionString)
{
    try
    {
        using (var conn = new SqlConnection(connectionString))
        {
            conn.Open();
            return true;
        }
    }
    catch
    {
        return false;
    }
}

void StartDockerCompose()
{
    var process = new Process
    {
        StartInfo = new ProcessStartInfo
        {
            FileName = "docker-compose",
            Arguments = "up -d",
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
            WorkingDirectory = Directory.GetCurrentDirectory()
        }
    };
    process.Start();
    string output = process.StandardOutput.ReadToEnd();
    string err = process.StandardError.ReadToEnd();
    process.WaitForExit();

    Console.WriteLine("Docker Compose output:\n" + output);
    if (!string.IsNullOrEmpty(err))
        Console.WriteLine("Docker Compose errors:\n" + err);
}

// ---- Development-time Docker Compose Logic ----
if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
{
    // Put your Docker SQL Server connection string here
    string connectionString = "Server=localhost,1433;User Id=sa;Password=pAssword1;TrustServerCertificate=True;";

    if (IsSqlServerAvailable(connectionString))
    {
        Console.WriteLine("SQL Server is already running. Skipping Docker Compose startup.");
    }
    else
    {
        try
        {
            StartDockerCompose();
            Console.WriteLine("Docker Compose started (or already running).");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to start Docker Compose: " + ex.Message);
        }
    }
}

var builder = WebApplication.CreateBuilder(args);

builder.Services.LoadDataLayerExtension(builder.Configuration); // ImageHelper için DI cercevesi

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation(); // Kaydedilenler anlik olarak yansimasi icin

builder.Services.AddSession();

builder.Services.AddAuthentication(
      CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(x =>
          {
              x.LoginPath = "/AdminLogin/Index";  // Giris yapmadiginda bu sayfaya yonlendirecek
          }
      );

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60); //siteye login olduktan 60 dk sonra otomatik cikis yapar
    options.LoginPath = "/AdminLogin/Index/";
    options.SlidingExpiration = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
