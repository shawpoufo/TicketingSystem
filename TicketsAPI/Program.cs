
using Microsoft.EntityFrameworkCore;
using TicketsAPI.DbContext;
using TicketsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5002");
builder.Services.AddDbContext<AppDbContext>(options=> {
    string cnnString = builder.Configuration.GetSection("UseDocker").Get<bool>() ? "DockerConnection":"DefaultConnection";
    options.UseNpgsql(builder.Configuration.GetConnectionString(cnnString));
});
builder.Services.AddTransient<TicketRepository>();
builder.Services.AddControllers().AddNewtonsoftJson();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();









