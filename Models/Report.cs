using System.Text.Json.Serialization;

namespace XivVoicesService.Models;

public enum Gender
{
    Male,
    Female
}


public class Report
{
    public required string Id { get; init; } = Guid.NewGuid().ToString();
    public required string Speaker { get; set; }
    public required string Sentence { get; set; }
    public required string NpcId { get; set; }
    public required string SkeletonId { get; set; }
    public required string Body { get; set; } // TODO: Make an enum?
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required Gender Gender { get; set; }
    public required string Race { get; set; }
    public required string Tribe { get; set; }
    public required string Eyes { get; set; }
    public required string Folder { get; set; }
    public required string User { get; set; }
    public string? Comment { get; set; }
}
