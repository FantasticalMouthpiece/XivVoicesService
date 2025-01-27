using XivVoicesService.DTOs.Report;

namespace XivVoicesService.Models;

public interface IReportRepository
{
    Task<IEnumerable<Report>> GetReports();
    Task<Report?> GetReport(string reportId);
    Task<Report> AddReport(ReportCreateDTO report);
    Task<Report?> SaveReport(Report report);
}