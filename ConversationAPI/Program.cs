using ConversationAPI.DBContext;
using ConversationAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options=>
    options.UseNpgsql(@"Host=localhost;Username=postgres;Password=postgres;Database=conversation"));
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddTransient<MessageRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
