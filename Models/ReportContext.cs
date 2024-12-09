using Microsoft.EntityFrameworkCore;

namespace XivVoicesService.Models;

public class XivVoicesServiceDbContext(DbContextOptions<XivVoicesServiceDbContext> options) : DbContext(options)
{
    public DbSet<Report> Reports { get; set; }
}