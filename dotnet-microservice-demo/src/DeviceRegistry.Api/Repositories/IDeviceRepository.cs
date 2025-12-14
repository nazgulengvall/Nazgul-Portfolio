using DeviceRegistry.Api.Domain;

namespace DeviceRegistry.Api.Repositories;

public interface IDeviceRepository
{
    Task<IEnumerable<Device>> GetAllAsync();
    Task<Device?> GetByIdAsync(int id);
    Task AddAsync(Device device);
}
