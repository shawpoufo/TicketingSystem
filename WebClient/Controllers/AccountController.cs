
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;
using WebClient.Services;

public class AccountController : Controller{

    private readonly AuthService _authService;
    private readonly IDataProtectionProvider _provider;

    public AccountController(AuthService authService,IDataProtectionProvider provider)
    {
        _provider = provider;
        _authService = authService;
    }

    [HttpGet]
    public IActionResult SignUp() => View();


    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel model)
    {
        if(!ModelState.IsValid)
            return View(model);
        
        var (succeded,_) = await _authService.SignUp(model.UserName,model.Password,1);

        if(!succeded)
            return View(model);
        
        return RedirectToAction(nameof(Login));
    }

    public IActionResult Login(string? ReturnUrl){
        ViewBag.ReturnUrl = ReturnUrl ?? "";
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model){
        if(!ModelState.IsValid)
            return View(model);
        
        var (cookie,role) = await _authService.Login(model.UserName , model.Password);
        if(cookie == null)
        {
            ViewBag.BadCredentials = "Invalide Credentials";
            return View(model);
        }
        HttpContext.Response.Headers.Add("Set-Cookie",cookie.cookie);
        if(role == "User")
            return RedirectToAction("Index","UserDashBoard");
        return RedirectToAction("index","organisation");    
    }

    public async Task<IActionResult> Logout(){
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Index","Home");
    }
    private void Decrypt(string cookie){
        var dataProtector = _provider.CreateProtector("MyApp",CookieAuthenticationDefaults.AuthenticationScheme);
        // var coded = dataProtector.Protect("HELLO");
        string coded = cookie.Split('=')[1].Split(';')[0];
        var decode = dataProtector.Unprotect(coded);
        Console.WriteLine(decode);

    }
}