using System.Text;
using Newtonsoft.Json;

public class ConversationService{
    private readonly HttpClient _httpClient;
    private const string _serviceName = "conversationservice";

    public ConversationService(HttpClient httpClient){
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5000/");
        _httpClient.DefaultRequestHeaders.Add("accept","application/json");
    }

    public async Task<List<Message>> GetConversation(int ticketId){
        var response = await _httpClient.GetAsync(_serviceName+"/conversation/"+ticketId);
        if(response.IsSuccessStatusCode)
        {
            string contentStr = await response.Content.ReadAsStringAsync();
            var messages =  JsonConvert.DeserializeObject<List<Message>>(contentStr);
            if(messages == null)
                return new List<Message>();
            
            return messages;
        }

        return new List<Message>();
    }

    public async Task<Message?> create( int UserId , int TicketId , string Text){
        var content = JsonConvert.SerializeObject(new { UserId , TicketId , Text});
        var httpContent = new StringContent(content,Encoding.UTF8,"application/json");
        var response = await _httpClient.PostAsync(_serviceName+"/conversation",httpContent);
        if(response.IsSuccessStatusCode){
            return JsonConvert.DeserializeObject<Message>(await response.Content.ReadAsStringAsync());
        }
        return null;
        
    }
}
public record Message(int Id, int UserId , int TicketId , string Text , DateTime CreatedAt);