var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5000");
// Add services to the container.
var reverseProxyConfig = builder.Configuration.GetSection("UseDocker").Get<bool>() ? "ReverseProxyDocker":"ReverseProxy";
Console.WriteLine(reverseProxyConfig);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection(reverseProxyConfig));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
 
}


// app.UseHttpsRedirection();

// app.UseAuthorization();
app.MapReverseProxy();
// app.MapControllers();

app.Run();
