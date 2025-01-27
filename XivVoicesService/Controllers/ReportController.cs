using Microsoft.AspNetCore.Mvc;
using XivVoicesService.DTOs.Report;
using XivVoicesService.Models;

namespace XivVoicesService.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController(ILogger<ReportController> logger, IReportRepository reportRepository) : ControllerBase
{
    private readonly ILogger<ReportController> _logger = logger;

    [HttpGet(Name = "GetReports")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReports()
    {
        var results = await reportRepository.GetReports();
        
        return Ok(results);
    }

    [HttpPost(Name = "CreateReport")]
    [
        ProducesResponseType(StatusCodes.Status201Created),
        ProducesResponseType(StatusCodes.Status400BadRequest)
    ]
    public async Task<IActionResult> CreateReport([FromBody] ReportCreateDTO report)
    {
        var results = await reportRepository.AddReport(report);
        
        return CreatedAtAction(nameof(GetReports), new { reportId = results.Id }, results);
    }
}