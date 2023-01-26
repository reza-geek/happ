using backend.Models;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString1 = builder.Configuration.GetConnectionString("myDb1");
builder.Services.AddDbContext<Hospital_DBN2>(x => x.UseSqlServer(connectionString1));
builder.Services.AddMvc().AddJsonOptions(options =>
{
   options.JsonSerializerOptions.PropertyNamingPolicy = null;
});;

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
   // app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
