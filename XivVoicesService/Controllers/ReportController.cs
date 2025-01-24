using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XivVoicesService.Models;

namespace XivVoicesService.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController(ILogger<ReportController> logger, ReportDbContext reportDbContext) : ControllerBase
{
    private readonly ILogger<ReportController> _logger = logger;

    [HttpGet(Name = "GetReports")]
    public async Task<IActionResult> GetReports()
    {
        var result = await reportDbContext.Reports.Select(report => new Report
        {
            Id = report.Id,
            Body = report.Body,
            Eyes = report.Eyes,
            Folder = report.Folder,
            Gender = report.Gender,
            Race = report.Race,
            Sentence = report.Sentence,
            Speaker = report.Speaker,
            Tribe = report.Tribe,
            User = report.User,
            NpcId = report.NpcId,
            SkeletonId = report.SkeletonId,
            Comment = report.Comment,
        }).ToListAsync();
        
        return Ok(result);
    }
}