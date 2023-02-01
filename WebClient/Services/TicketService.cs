using System.Text;
using Newtonsoft.Json;
using WebClient.Models;

public class TicketService{
    private readonly HttpClient _httpClient;
    private readonly UserService _userService;
    private const string _serviceName = "ticketservice";

    public TicketService(HttpClient httpClient , UserService userService,IConfiguration configuration){
        string gateWayHostName = configuration.GetSection("UseDocker").Get<bool>() ? "gateway" : "localhost";

        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"http://{gateWayHostName}:5000/");
        _httpClient.DefaultRequestHeaders.Add("accept","application/json");
        _userService = userService;
    }

    public async Task<List<TicketViewModel>?> GetAll(int organisationId){
        var response = await _httpClient.GetAsync(_serviceName+"/ticket/organisation/"+organisationId);
        if(response.IsSuccessStatusCode)
        {
            string contentStr = await response.Content.ReadAsStringAsync();
            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(contentStr);
            if(tickets == null || tickets.Count == 0)
                return new List<TicketViewModel>();
            
            var clientsId = tickets?.Select(t => t.ClientId).ToHashSet();
            var agentsId = tickets?.Where(t => t.AgentId != null).Select(t => (int)t.AgentId).ToHashSet();
            foreach(var i in clientsId){
                agentsId.Add(i);
            }
            var users = await _userService.GetMany(agentsId.ToArray());
            var ticketViewModels = tickets.Select(t => {
                return new TicketViewModel{
                    Id = t.Id,
                    Status = t.status.ToString(),
                    AgentName = users?.FirstOrDefault(u => u.Id == t.AgentId)?.Name ,
                    ClientName = users?.FirstOrDefault(u => u.Id == t.ClientId).Name,
                    CreatedAt = t.CreatedAt.ToShortDateString(),
                    Title = t.Title,
                    Description = t.Description
                };
            });
            return ticketViewModels.ToList();
        }

        return null;
    }

    public async Task<(bool isSucceed,Ticket? ticket)> create(int clientId,int organisationId,string title,string description){
        var content = JsonConvert.SerializeObject(new {clientId,organisationId,title,description});
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsync(_serviceName+"/ticket",httpContent);
        if(!response.IsSuccessStatusCode)
            return(false,null);
        var newTicket = JsonConvert.DeserializeObject<Ticket>(await response.Content.ReadAsStringAsync());

        return (response.IsSuccessStatusCode,newTicket);
    }

    public async Task<(Ticket? ticket,OrgUser? agent)> Assign(int id , int agentId){
        var content = JsonConvert.SerializeObject(new object[]{
            new {
                op = "replace",
                path="/status",
                value="Processing"
            },
            new {
                op = "replace",
                path="/AgentId",
                value=agentId
            }
        });
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PatchAsync($"{_serviceName}/ticket/{id}",httpContent);
        if(!response.IsSuccessStatusCode)
            return (null,null);
        var ticket = await response.Content.ReadFromJsonAsync<Ticket>();
        var agent = await _userService.GetMany(new[]{agentId});
        
        return (ticket,agent?.FirstOrDefault());

    }
     public async Task<bool> Close(int id , int clientId){
        var content = JsonConvert.SerializeObject(new object[]{
            new {
                op = "replace",
                path="/status",
                value="Closed"
            },
        });
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PatchAsync($"{_serviceName}/ticket/{id}",httpContent);
        return response.IsSuccessStatusCode;
    }

    public async Task<List<TicketViewModel>> GetAllByUserId(int userId){
        var response = await _httpClient.GetAsync($"{_serviceName}/ticket/user/{userId}");
        if(response.IsSuccessStatusCode)
        {
            string contentStr = await response.Content.ReadAsStringAsync();
            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(contentStr);
            if(tickets == null || tickets.Count == 0)
                return new List<TicketViewModel>();
            
            var agentsId = tickets?.Where(t => t.AgentId != null).Select(t => (int)t.AgentId).ToHashSet();

            var users = await _userService.GetMany(agentsId.ToArray());
            var ticketViewModels = tickets.Select(t => {
                return new TicketViewModel{
                    Id = t.Id,
                    Status = t.status.ToString(),
                    AgentName = users?.FirstOrDefault(u => u.Id == t.AgentId)?.Name ,
                    ClientName = string.Empty,
                    CreatedAt = t.CreatedAt.ToShortDateString(),
                    Title = t.Title,
                    Description = t.Description
                };
            });
            return ticketViewModels.ToList();
        }

        return new List<TicketViewModel>();
    }
}

public record Ticket(int Id,string Title,string Description,Status status,DateTime CreatedAt,int ClientId,int? AgentId,int OrganisationId);


public enum Status {New,Processing,Closed}