using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using XivVoicesService.DTOs.Report;

namespace XivVoicesService.Models;

public class ReportRepository(AppDbContext context) : IReportRepository
{
    public async Task<IEnumerable<Report>> GetReports()
    {
        return await context.Reports.ToListAsync();
    }

    public async Task<Report?> GetReport(string id)
    {
        return await context.Reports.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Report> AddReport(ReportCreateDTO report)
    {
        var result = await context.Reports.AddAsync(new Report
        {
            Id = Guid.NewGuid().ToString(),
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
        });
        await context.SaveChangesAsync();
        
        return result.Entity;
    }

    public async Task<Report?> SaveReport(Report report)
    {
        var result = await context.Reports.FirstOrDefaultAsync(entity => entity.Id == report.Id);

        if (result == null) return null;
        
        result.Body = report.Body;
        result.Comment = report.Comment;
        result.Eyes = report.Eyes;
        result.Race = report.Race;
        result.Folder = report.Folder;
        result.Gender = report.Gender;
        result.Sentence = report.Sentence;
        result.Speaker = report.Speaker;
        result.Tribe = report.Tribe;
        result.User = report.User;
        result.NpcId = report.NpcId;
        result.SkeletonId = report.SkeletonId;
            
        await context.SaveChangesAsync();
            
        return result;

    }
}