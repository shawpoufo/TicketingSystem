using System.Text;
using System.Web;
using Newtonsoft.Json;

public class UserService{
    private readonly HttpClient _httpClient;
    private const string _serviceName = "userservice";

    public UserService(HttpClient httpClient){
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        _httpClient.DefaultRequestHeaders.Add("accept","application/json");
    }

    public async Task<bool> Create(int id , int organisationId , string name, int roleId){
        var content = JsonConvert.SerializeObject(new { 
            id ,
            organisationId,
            name,
            roleId  
        });
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsync(_serviceName+"/user",httpContent);
        return response.IsSuccessStatusCode;
    }


    private string GenerateUrlParameter(int[] arr){
        StringBuilder stringBuilder = new StringBuilder();
        foreach(int i in arr){
            stringBuilder.Append($"ids={i}&");
        }
        stringBuilder.Remove(stringBuilder.Length -1,1);

        return stringBuilder.ToString();

    }
    public async Task<List<OrgUser>?> GetMany(int[] ids){
        var p = GenerateUrlParameter(ids);
        var response = await _httpClient.GetAsync($"{_serviceName}/user?{p}");
        if(response.IsSuccessStatusCode){
            return  await response.Content.ReadFromJsonAsync<List<OrgUser>>();
        }
        return null;
    }
    public async Task<List<OrgUser>?> GetMany(int orgId , int roleId){
        var response = await _httpClient.GetAsync($"{_serviceName}/user/organisation/{orgId}/role/{roleId}");
        if(response.IsSuccessStatusCode){
            return  await response.Content.ReadFromJsonAsync<List<OrgUser>>();
        }
        return null;
    }
    public async Task<OrgUser?> Get(int id){
        var response = await _httpClient.GetAsync($"{_serviceName}/user/{id}");
        if(response.IsSuccessStatusCode){
            return  await response.Content.ReadFromJsonAsync<OrgUser>();
        }
        return null;
    }

}
public record OrgUser(int Id ,string Name, int OrganisationId ,int RoleId);