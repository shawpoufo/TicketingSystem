using OrganisationAPI.AppDBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganisationAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5003");
builder.Services.AddDbContext<AppDbContext>(options =>{
    string cnnString = builder.Configuration.GetSection("UseDocker").Get<bool>() ? "DockerConnection":"DefaultConnection";
    options.UseNpgsql(builder.Configuration.GetConnectionString(cnnString));
});
builder.Services.AddTransient<OrganisationRepository>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
