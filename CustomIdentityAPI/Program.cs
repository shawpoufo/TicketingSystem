using CustomIdentityAPI.DbContexts;
using CustomIdentityAPI.Models;
using CustomIdentityAPI.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5001");
// Add services to the container.


builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<LoginRepository>();
builder.Services.AddTransient<PasswordHasher<Login>>();
builder.Services.AddTransient<PwdHash>();
builder.Services.AddDbContext<ApplicationDbContext>(options=>
 {
    string cnnString = builder.Configuration.GetSection("UseDocker").Get<bool>() ? "DockerConnection":"DefaultConnection";
    options.UseNpgsql(builder.Configuration.GetConnectionString(cnnString));
 }
);
// builder.Services.AddHttpClient();
// builder.Services.AddHttpContextAccessor();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("../KEYS"))
    .SetApplicationName("MyApp").SetDefaultKeyLifetime(new TimeSpan(180,0,0,0));

builder.Services.AddAuthentication()
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
       app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
