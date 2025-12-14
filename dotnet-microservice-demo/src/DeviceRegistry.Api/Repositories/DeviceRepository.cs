using DeviceRegistry.Api.Data;
using DeviceRegistry.Api.Domain;
using Microsoft.EntityFrameworkCore;

namespace DeviceRegistry.Api.Repositories;

public class DeviceRepository : IDeviceRepository
{
    private readonly AppDbContext _context;

    public DeviceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Device>> GetAllAsync()
    {
        return await _context.Devices.ToListAsync();
    }

    public async Task<Device?> GetByIdAsync(int id)
    {
        return await _context.Devices.FindAsync(id);
    }

    public async Task AddAsync(Device device)
    {
        _context.Devices.Add(device);
        await _context.SaveChangesAsync();
    }
}
