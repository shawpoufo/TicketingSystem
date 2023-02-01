using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using WebClient.Hubs;
using WebClient.Services;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("http://*:5005");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<AuthService>();
builder.Services.AddHttpClient<UserService>();
builder.Services.AddHttpClient<ConversationService>();
builder.Services.AddHttpClient<TicketService>();
builder.Services.AddHttpClient<OrganisationService>();

builder.Services.AddSingleton<ConnectedUsers>();

builder.Services.AddSignalR();

builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo("../KEYS"))
    .SetApplicationName("MyApp")
    .DisableAutomaticKeyGeneration();

builder.Services.AddAuthorization(o => {
    o.AddPolicy("admin", p =>{
        p.RequireRole("admin").RequireAuthenticatedUser();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapHub<TicketHub>("/hub/ticket");
app.MapHub<UserHub>("/hub/user");
app.MapHub<ConversationHub>("/hub/conversation");
app.Run();
