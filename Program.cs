using Microsoft.EntityFrameworkCore;
using InmobiliariaCC.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexión de Entity Framework con MySQL
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseMySQL(
        builder.Configuration.GetConnectionString("CadenaSQL")!
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();