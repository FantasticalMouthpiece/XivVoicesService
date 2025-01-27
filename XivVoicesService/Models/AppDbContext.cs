using Microsoft.EntityFrameworkCore;

namespace XivVoicesService.Models;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Report> Reports { get; set; }
}