
using Microsoft.EntityFrameworkCore;
using TicketsAPI.DbContext;
using TicketsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=tickets"));

builder.Services.AddTransient<TicketRepository>();
builder.Services.AddControllers().AddNewtonsoftJson();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();









