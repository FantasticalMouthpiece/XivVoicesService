using Microsoft.EntityFrameworkCore;

namespace XivVoicesService.Models;

public class ReportDbContext(DbContextOptions<ReportDbContext> options) : DbContext(options)
{
    public DbSet<Report> Reports { get; set; }
}