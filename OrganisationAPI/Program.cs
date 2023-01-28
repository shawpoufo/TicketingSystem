using OrganisationAPI.AppDBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganisationAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=Orgs"));
builder.Services.AddTransient<OrganisationRepository>();
builder.Services.AddTransient<UserRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
