using backend.App_start;
using backend.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using backend.Models.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString1 = builder.Configuration.GetConnectionString("myDb1");
builder.Services.AddDbContext<Hospital_DBN>(x => x.UseSqlServer(connectionString1));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<JwtHandler>();
builder.Services.AddScoped<PatientRepository>();
builder.Services.AddScoped<PartRepository>();
builder.Services.AddScoped<EventRepository>();
builder.Services.AddScoped<CatheterRepository>();
builder.Services.AddScoped<CatheterEjectRepository>();
builder.Services.AddScoped<ClearanceRepository>();
builder.Services.AddScoped<DoctorRepository>(); 

builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();

//builder.Services.AddIdentity<User, IdentityRole> (options =>
//{
//    options.User.RequireUniqueEmail = false;
//})//.AddEntityFrameworkStores <Hospital_DBN>()
//.AddDefaultTokenProviders(); 

builder.Services.AddMvc().AddJsonOptions(options =>
{
   options.JsonSerializerOptions.PropertyNamingPolicy = null;
});

// let’s modify the Program class and register the JWT authentication right below the AddEntityFrameworkStores<RepositoryContext>() method:
var jwtSettings = builder.Configuration.GetSection("JWtConfig");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
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
        ValidIssuer = jwtSettings["issuer"],
        ValidAudience = jwtSettings["audience"],
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8
            .GetBytes(jwtSettings.GetSection("key").Value))
    }; 
    options.SaveToken = true; // HttpContext.GetTokenAsync
    options.Events = new JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            return Task.CompletedTask;
        },
        OnMessageReceived = context =>
         {
             return Task.CompletedTask;
         },
        OnForbidden = context =>
        {
            return Task.CompletedTask;
        }

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
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
} 
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
