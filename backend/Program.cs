using backend.App_start;
using backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString1 = builder.Configuration.GetConnectionString("myDb1");
builder.Services.AddDbContext<Hospital_DBN2>(x => x.UseSqlServer(connectionString1));

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddIdentity<User, IdentityRole> (options =>
{
    options.User.RequireUniqueEmail = false;
})//.AddEntityFrameworkStores <Hospital_DBN2>()
.AddDefaultTokenProviders(); 

builder.Services.AddMvc().AddJsonOptions(options =>
{
   options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// let’s modify the Program class and register the JWT authentication right below the AddEntityFrameworkStores<RepositoryContext>() method:
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(jwtSettings.GetSection("securityKey").Value))
    };

});

var app = builder.Build();
//Also, we have to add Authentication and Authorization to the request pipeline:
app.UseAuthentication();
app.UseAuthorization();

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
