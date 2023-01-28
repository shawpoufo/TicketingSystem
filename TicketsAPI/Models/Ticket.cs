using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace TicketsAPI.Models;

public class Ticket{
    public int Id { get; set; }
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public Status status { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public int ClientId { get; set; }
    public int? AgentId { get; set; }
    public int OrganisationId { get; set; }
}
public enum Status {New,Processing,Closed}
