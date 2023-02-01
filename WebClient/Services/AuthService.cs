using System.Text;
using Newtonsoft.Json;

namespace WebClient.Services;
public class AuthService{

    private readonly HttpClient _httpClient;
    private const string _serviceName = "authservice";
    public int HI { get; set; }
    public AuthService(HttpClient httpClient,IConfiguration configuration)
    {
        string gateWayHostName = configuration.GetSection("UseDocker").Get<bool>() ? "gateway" : "localhost";

        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"http://{gateWayHostName}:5000/");
        _httpClient.DefaultRequestHeaders.Add("accept","application/json");
    }
    
    public async Task<(bool succes , int userId)> SignUp(string username , string password , int roleId){
        // validation is done in the WebClient Auth Controller :)
        var content = JsonConvert.SerializeObject(new {username,password,roleId});
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsync(_serviceName+"/auth/signup",httpContent);
        if(!response.IsSuccessStatusCode)
            return (false,0);
        var responeContent = await response.Content.ReadAsStringAsync();
        var userId = JsonConvert.DeserializeObject<int>(responeContent);
        return (true, userId);
    }
    public async Task<(AuthCookie? cookie,string? role)> Login (string username , string password){
        var content = JsonConvert.SerializeObject(new {username,password});
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsync(_serviceName+"/auth/login",httpContent);
        if(response.IsSuccessStatusCode){
            var cookie = response.Headers.FirstOrDefault(h => (String.Compare(h.Key , "set-cookie",true) == 0 ? true:false)).Value.FirstOrDefault();
            var role = response.Headers.FirstOrDefault(h => h.Key == "role").Value.FirstOrDefault();
            if(!string.IsNullOrEmpty(cookie))
                return (new AuthCookie(cookie),role);
        }
        return (null,null);
    }
    
}
public record AuthCookie(string cookie);

