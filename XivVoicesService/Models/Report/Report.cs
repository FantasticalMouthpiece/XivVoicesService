namespace XivVoicesService.Models;

public class Report
{
    public required string Id { get; init; }
    public required string Speaker { get; set; }
    public required string Sentence { get; set; }
    public required int NpcId { get; set; }
    public required int SkeletonId { get; set; }
    public required string Body { get; set; }
    public required string Gender { get; set; }
    public required string Race { get; set; }
    public required string Tribe { get; set; }
    public required string Eyes { get; set; }
    public required string Folder { get; set; }
    public required string User { get; set; }
    public string? Comment { get; set; }
}