using Microsoft.EntityFrameworkCore;
using DeviceRegistry.Api.Domain;

namespace DeviceRegistry.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Device> Devices => Set<Device>();
}
