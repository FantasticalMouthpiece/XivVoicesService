using System.ComponentModel.DataAnnotations;

namespace XivVoicesService.Models;

public class Report
{
    [ScaffoldColumn(false)]
    public required string Id { get; set; }
    public required string Speaker { get; set; }
    public required string Sentence { get; set; }
    public required string NpcId { get; set; }
    public required string SkeletonId { get; set; }
    public required string Body { get; set; }
    public required string Gender { get; set; }
    public required string Race { get; set; }
    public required string Tribe { get; set; }
    public required string Eyes { get; set; }
    public required string Folder { get; set; }
    public required string User { get; set; }
    public string? Comment { get; set; }
}