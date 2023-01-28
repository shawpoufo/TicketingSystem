using System.Text;
using Newtonsoft.Json;

public class OrganisationService{
    private readonly HttpClient _httpClient;
    private const string _serviceName = "organisationservice";

    public OrganisationService(HttpClient httpClient){
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        _httpClient.DefaultRequestHeaders.Add("accept","application/json");
    }

    public async Task<List<Organisation>> GetAllByManagerId(int id){
        var response = await _httpClient.GetAsync(_serviceName+"/organisation/manager/"+id);
        if(response.IsSuccessStatusCode)
        {
            string contentStr = await response.Content.ReadAsStringAsync();
            var organisations = JsonConvert.DeserializeObject<List<Organisation>>(contentStr);
            return organisations ?? new List<Organisation>();
        }
        return new List<Organisation>();

    }

    public async Task<Organisation?> create(int managerId , string name){
        var content = JsonConvert.SerializeObject(new { managerId,name });
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsync(_serviceName+"/organisation",httpContent);
        if(response.IsSuccessStatusCode){
            return JsonConvert.DeserializeObject<Organisation>(await response.Content.ReadAsStringAsync());
        }
        return null;
        
    }

    public async Task<Organisation ?> Get(int id){
        var respone = await _httpClient.GetAsync(_serviceName+"/organisation/"+id);
        if(respone.IsSuccessStatusCode){
            return JsonConvert.DeserializeObject<Organisation>(await respone.Content.ReadAsStringAsync());
        }
        return null;

    }
}
public record Organisation(int Id, string Name , int ManagerId , int userCount);