using ConversationAPI.DBContext;
using ConversationAPI.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5004");
builder.Services.AddDbContext<AppDbContext>(options=>
    {
        string cnnString = builder.Configuration.GetSection("UseDocker").Get<bool>() ? "DockerConnection":"DefaultConnection";
        options.UseNpgsql(builder.Configuration.GetConnectionString(cnnString));
    });
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddTransient<MessageRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
