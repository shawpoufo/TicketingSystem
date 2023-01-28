using UserAPI.AppDBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserAPI.Repositories;
using UserAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(o => o.UseInMemoryDatabase("db"));
builder.Services.AddTransient<OrgUserRepository>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", (AppDbContext c) => {
    c.Roles.AddRange(new UserRole{Id=1,Label="manager"},
                new UserRole{Id=2,Label="agent"},
                new UserRole{Id=3,Label="client"});
                c.SaveChanges();
});
app.MapControllers();
app.Run();
